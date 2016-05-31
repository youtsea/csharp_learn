using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//支持bit mask的枚举
namespace cook_book.ch_03
{
    class ch_03_10
    {
        public static void Test()
        {
            RecycleItems items = RecycleItems.Glass | RecycleItems.Newspaper;
            if ((items & RecycleItems.Glass) == RecycleItems.Glass)
            {
                Console.WriteLine("The enum contains the C# enumeration value");
            }
            else
            {
                Console.WriteLine("The enum does NOT contain the C# value");
            }
        }
    }

    [Flags]
    public enum RecycleItems
    {
        None = 0x00,
        Glass = 0x01,
        AluminumCans = 0x02,
        MixedPaper = 0x04,
        Newspaper = 0x08
    }
}
