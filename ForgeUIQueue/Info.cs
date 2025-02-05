using System.IO;
using System.Net.Http;

namespace ForgeUIQueue
{
    public static class Info
    {
        public static CfrmMain _main;

        public static Settings _settings;
        static string _settingsPath = "settings.dat";

        public static readonly HttpClient _client = new HttpClient();
        public static readonly string _apiUrlTxt2Img = "http://localhost:7860/sdapi/v1/txt2img";
        public static readonly string _apiUrlSkip = "http://localhost:7860/sdapi/v1/skip";

        public static bool _paused = false;

        public static void SaveSettings()
        {
            Data.Save(_settingsPath, _settings);
        }

        public static void LoadSettings()
        {
            if (File.Exists(_settingsPath))
            {
                _settings = (Settings)Data.Load(_settingsPath);
            }
            else
            {
                _settings = new Settings();
                SaveSettings();
            }
        }
    }
}
