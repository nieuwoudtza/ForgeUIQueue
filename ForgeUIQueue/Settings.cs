using System;
using System.Collections.Generic;

namespace ForgeUIQueue
{
    [Serializable]
    public class Settings
    {
        public int Port = 7860;
        public string OutputDirectory = "ForgeOutput";
        public ThreadSafeList<Payload> Payloads = new ThreadSafeList<Payload>();
        public ThreadSafeList<Payload> HistoricalPayloads = new ThreadSafeList<Payload>();
    }
}
