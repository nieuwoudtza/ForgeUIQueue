using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ForgeUIQueue
{
    public class ForgeUI
    {
        ThreadSafeList<Payload> _payloads;
        bool _running = false;

        public bool Running { get => _running; }

        public ForgeUI()
        {
            _payloads = new ThreadSafeList<Payload>();
        }

        public int AddPayload(Payload payload)
        {
            int id = 0;
            while (_payloads.Any(x => x.ID == id))
            {
                id++;
            }
            payload.ID = id;
            _payloads.Add(payload);
            Info._settings.Payloads = _payloads;
            Info.SaveSettings();
            ProcessPayloads();

            return id;
        }

        public void AddPayloadToHistory(Payload payload)
        {
            var lastPayload = Info._settings.HistoricalPayloads.FirstOrDefault();

            bool add = false;
            if (lastPayload == null)
            {
                add = true;
            }
            else if (!payload.Prompt.Equals(lastPayload.Prompt, StringComparison.OrdinalIgnoreCase))
            {
                add = true;
            }
            else if (payload.Width != lastPayload.Width)
            {
                add = true;
            }
            else if (payload.Height != lastPayload.Height)
            {
                add = true;
            }
            else if (payload.Steps != lastPayload.Steps)
            {
                add = true;
            }

            if (add)
            {
                Info._settings.HistoricalPayloads.Insert(0, payload);
            }
        }

        public void DeletePayload(int id)
        {
            var payload = _payloads.Where(x => x.ID == id).FirstOrDefault();
            if (payload != null)
            {
                payload.Count = 0;
                _payloads.Remove(payload);
                Info._main.UpdatePayload(payload);
                Info._settings.Payloads = _payloads;
                Info.SaveSettings();
            }
        }

        public void UpdatePayload(int id, string prompt = null, int? width = null, int? height = null, int? steps = null, int? count = null)
        {
            var payload = _payloads.Where(x => x.ID == id).FirstOrDefault();
            if (payload == null)
            {
                return;
            }

            if (prompt != null)
            {
                payload.Prompt = prompt;
            }
            if (width != null)
            {
                payload.Width = width.Value;
            }
            if (height != null)
            {
                payload.Height = height.Value;
            }
            if (steps != null)
            {
                payload.Steps = steps.Value;
            }
            if (count != null)
            {
                payload.Count = count.Value;
            }

            Info._main.UpdatePayload(payload);
            Info._settings.Payloads = _payloads;
            Info.SaveSettings();
        }

        public Payload GetPayload(int id)
        {
            return _payloads.Where(x => x.ID == id).FirstOrDefault();
        }

        public void SkipCurrentGeneration()
        {
            try
            {
                _ = Info._client.PostAsync(Info._apiUrlSkip, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void PayloadUp(int id)
        {
            // Find the payload with the given id.
            var payload = _payloads.FirstOrDefault(x => x.ID == id);
            if (payload == null)
                return;

            int index = _payloads.IndexOf(payload);
            // Can't move up if it's already at the top.
            if (index <= 0)
                return;

            // Swap with the previous element.
            Payload temp = _payloads[index - 1];
            _payloads[index - 1] = _payloads[index];
            _payloads[index] = temp;

            Info._settings.Payloads = _payloads;
            Info.SaveSettings();
        }

        public void PayloadDown(int id)
        {
            // Find the payload with the given id.
            var payload = _payloads.FirstOrDefault(x => x.ID == id);
            if (payload == null)
                return;

            int index = _payloads.IndexOf(payload);
            // Can't move down if it's the last element.
            if (index < 0 || index >= _payloads.Count - 1)
                return;

            // Swap with the next element.
            Payload temp = _payloads[index + 1];
            _payloads[index + 1] = _payloads[index];
            _payloads[index] = temp;

            Info._settings.Payloads = _payloads;
            Info.SaveSettings();
        }

        void DecreasePayloadCount(int id)
        {
            var payload = _payloads.Where(x => x.ID == id).FirstOrDefault();
            if (payload != null)
            {
                payload.Count--;
                if (payload.Count == 0)
                {
                    DeletePayload(id);
                    Info.SaveSettings();
                }
                else
                {
                    Info._main.UpdatePayload(payload);
                    Info._settings.Payloads = _payloads;
                    Info.SaveSettings();
                }
            }
        }

        async void ProcessPayloads()
        {
            if (Running)
            {
                return;
            }

            _running = true;

            while (_payloads.Count != 0)
            {
                while (Info._paused)
                {
                    await Task.Delay(500);
                }

                var payload = _payloads[0];
                while (payload.Count != 0)
                {
                    if (Info._paused)
                    {
                        break;
                    }

                    await Generate(payload);
                    DecreasePayloadCount(payload.ID);
                    if (_payloads.Count != 0)
                    {
                        payload = _payloads[0];
                    }
                }
            }

            _running = false;
        }

        async Task Generate(Payload payload)
        {
            try
            {
                Console.WriteLine($"Processing: {payload.Prompt}");

                var _payload = new
                {
                    prompt = payload.Prompt,
                    steps = payload.Steps,
                    width = payload.Width,
                    height = payload.Height,
                    scheduler = payload.Scheduler,
                    cfg_scale = payload.Cfg_scale
                };

                var content = new StringContent(JsonSerializer.Serialize(_payload), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await Info._client.PostAsync(Info._apiUrlTxt2Img, content);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"API Error: {await response.Content.ReadAsStringAsync()}");
                    return;
                }

                // Handle Forge's response format
                var jsonResponse = await response.Content.ReadAsStringAsync();
                using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                {
                    JsonElement root = doc.RootElement;

                    // Forge might return additional metadata
                    JsonElement images = root.GetProperty("images");
                    JsonElement info = root.GetProperty("parameters");

                    // Save with metadata
                    DateTime timestamp = DateTime.Now;
                    for (int k = 0; k < images.GetArrayLength(); k++)
                    {
                        string base64Image = images[k].GetString();
                        byte[] imageBytes = Convert.FromBase64String(base64Image);
                        //string filename = $"{Info._settings.OutputDirectory}\\{timestamp:yyyyMMdd-HHmmss}-{Tool.SanitizeFilename(payload.Prompt)}-{k}.png";
                        string filename = $"{Info._settings.OutputDirectory}\\{timestamp:yyyyMMdd-HHmmss}-{k}.png";
                        Directory.CreateDirectory(Info._settings.OutputDirectory);
                        File.WriteAllBytes(filename, imageBytes);
                    }
                }

                AddPayloadToHistory(payload);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Critical Error: {ex}");
            }
        }
    }
}
