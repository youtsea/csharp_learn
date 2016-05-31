using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//自动释放资源
namespace cook_book.ch_01
{
    class ch_01_08
    {
        public static void Test()
        {
            using (FileStream fs = new FileStream("Test.txt", FileMode.OpenOrCreate))
            {
                fs.WriteByte((byte)1);
                fs.WriteByte((byte)2);
                fs.WriteByte((byte)3);

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("some text.");
                }
            }
        }
    }
}
