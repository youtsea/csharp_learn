using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//字典排序
namespace cook_book.ch_02
{
    class ch_02_03
    {
        public static void Test()
        {
            Dictionary<string, string> hash = new Dictionary<string, string>()
            {
                ["2"] = "two",
                ["1"] = "one",
                ["5"] = "five",
                ["4"] = "four",
                ["3"] = "three"
            };

            var x = from k in hash.Keys orderby k ascending select k;

            foreach (var s in x)
            {
                Console.WriteLine($"Key: {s}  Value: {hash[s]}");
            }

            x = from k in hash.Values orderby k ascending select k;

            foreach (var s in x)
            {
                Console.WriteLine($"Value: {s}");
            }
        }
    }
}
