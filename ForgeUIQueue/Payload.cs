using System;

namespace ForgeUIQueue
{
    [Serializable]
    public class Payload
    {
        int id;
        string prompt;
        int width;
        int height;
        int steps;
        int count;
        string scheduler = "Simple";
        int cfg_scale = 1;

        public Payload(string prompt, int width, int height, int steps, int count)
        {
            this.prompt = prompt;
            this.width = width;
            this.height = height;
            this.steps = steps;
            this.count = count;
        }

        public int ID { get => id; set => id = value; }
        public string Prompt { get => prompt; set => prompt = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public int Steps { get => steps; set => steps = value; }
        public int Count { get => count; set => count = value; }
        public string Scheduler { get => scheduler; }
        public int Cfg_scale { get => cfg_scale; }
    }
}
