using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//空值判断
namespace cook_book.ch_01
{
    class ch_01_19
    {
        public static void Test()
        {
            string val = "123";
            if (val != null)
            {
                val.Trim().ToUpper();
            }

            val?.Trim().ToUpper();
        }
    }
}
