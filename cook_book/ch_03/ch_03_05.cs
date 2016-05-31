using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//判断字符串是否为数组
namespace cook_book.ch_03
{
    class ch_03_05
    {
        public static void Test()
        {
            string str = "12.5";
            double result = 0;
            if (double.TryParse(str, System.Globalization.NumberStyles.Float,
                System.Globalization.NumberFormatInfo.CurrentInfo,
                out result))
            {
                //
            }
        }
    }
}
