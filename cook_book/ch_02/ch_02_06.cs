using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cook_book.ch_02
{
    class ch_02_06
    {
        public static void Test()
        {
            List<string> strings = new List<string>() { "one", null, "three", "four" };

            string str = strings.TrueForAll(delegate(string val)
            {
                if (val == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }).ToString();

            Console.WriteLine(str);
        }
    }
}
