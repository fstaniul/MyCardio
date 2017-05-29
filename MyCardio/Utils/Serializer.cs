using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MyCardio.Utils
{
    public class Serializer
    {
        public static void Serialize(object o, string fileName)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, o);
                }
            }
            catch (IOException)
            {
                Debug.WriteLine("Failed to serialize object {0} to file {1}", o, fileName);
            }
        }

        public static T Deserialize<T>(string fileName)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return (T) formatter.Deserialize(stream);
                }
            }
            catch (IOException e)
            {
                Debug.WriteLine("Failed to read object from file {0}, cause of error {1}", fileName, e.Message);

                return default(T);
            }
        }
    }
}
