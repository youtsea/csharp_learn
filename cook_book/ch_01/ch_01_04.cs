using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//实现返回多值函数
namespace cook_book.ch_01
{
    class ch_01_04
    {
        public static Tuple<int, int, int> ReturnDimensionsAsTuple(int inputShape)
        {
            var objDim = Tuple.Create<int, int, int>(3, 4, 5);
            return objDim;
        }
    }
}
