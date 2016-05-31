using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

//持久化集合
namespace cook_book.ch_02
{
    class ch_02_05
    {
        public static void SerializeToFile<T>(T obj, string dataFile)
        {
            using (FileStream fileStream = File.Create(dataFile))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, obj);
            }
        }

        public static T DeserializeFromFile<T>(string dataFile)
        {
            T obj = default(T);
            using (FileStream fielStream = File.OpenRead(dataFile))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                obj = (T) binaryFormatter.Deserialize(fielStream);
            }

            return obj;;
        }
    }
}
