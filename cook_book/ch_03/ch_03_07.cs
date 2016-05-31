using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//四舍五入临界值算法
namespace cook_book.ch_03
{
    class ch_03_07
    {
        public static double RoundUp(double valueToRound) =>
            Math.Floor(valueToRound + 0.5);

        public static double RoundDown(double valueToRound)
        {
            double floorValue = Math.Round(valueToRound);
            if ((valueToRound - floorValue) > 0.5)
                return floorValue + 1;
            else
                return floorValue;
        }
    }
}
