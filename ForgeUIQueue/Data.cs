using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ForgeUIQueue
{
    public static class Data
    {
        public static void Save(string path, object obj)
        {
            if (obj == null)
                return;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            using (BinaryWriter bw = new BinaryWriter(fs))
                bw.Write(ms.ToArray());
        }

        public static object Load(string path)
        {
            byte[] arrBytes;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrBytes = new byte[fs.Length];

                using (BinaryReader br = new BinaryReader(fs))
                    br.Read(arrBytes, 0, arrBytes.Length);
            }

            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            object obj = binForm.Deserialize(memStream);

            return obj;
        }
    }
}
