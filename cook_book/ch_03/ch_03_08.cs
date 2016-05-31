using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//checked的使用，安全的执行数据转换
namespace cook_book.ch_03
{
    class ch_03_08
    {
    }

    public static class DataTypeExtMethods
    {
        public static int AddNarrowingChecked(this long lhs, long rhs)
        {
            return checked((int) (lhs + rhs));
        }
    }
}
