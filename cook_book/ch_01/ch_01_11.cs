using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//翻转有序列表
namespace cook_book.ch_01
{
    class ch_01_11
    {
        public static void Test()
        {
            SortedList<int, string> data = new SortedList<int, string>()
            {[2] = "two", [5] = "five", [3] = "three", [1] = "one"};

            foreach (KeyValuePair<int, string> kvp in data)
            {
                Console.WriteLine($"\t {kvp.Key} \t {kvp.Value}");
            }

            var query = from d in data
                orderby d.Key descending
                select d;
            foreach (KeyValuePair<int, string> kvp in query)
            {
                Console.WriteLine($"\t {kvp.Key} \t {kvp.Value}");
            }
        }
    }
}