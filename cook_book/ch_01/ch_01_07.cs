using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

//对象的深浅拷贝
namespace cook_book.ch_01
{
    class ch_01_07
    {
    }

    public interface IShallowCopy<T>
    {
        T ShallowCopy();
    }

    public interface IDeepCopy<T>
    {
        T DeepCopy();
    }

    public class ShallowClone : IShallowCopy<ShallowClone>
    {
        public int Data = 1;
        public List<string> ListData = new List<string>();
        public object ObjData = new object();

        public ShallowClone ShallowCopy() => (ShallowClone) this.MemberwiseClone();
    }

    [Serializable]
    public class DeepClone : IDeepCopy<DeepClone>
    {
        public int Data = 1;
        public List<string> ListData = new List<string>();
        public object ObjData = new object();
        public DeepClone DeepCopy()
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();

            bf.Serialize(memoryStream, this);
            memoryStream.Flush();
            memoryStream.Position = 0;

            return (DeepClone) bf.Deserialize(memoryStream);
        }
    }
}
