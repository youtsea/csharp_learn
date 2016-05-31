using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//finaly语句块和迭代器
namespace cook_book.ch_02
{
    class ch_02_08
    {
        public static void Test()
        {
            StringSet strSet =
                new StringSet()
                {
                    "item1",
                    "item2",
                    "item3",
                    "item4",
                    "item5"
                };

            foreach (string s in strSet)
                Console.WriteLine(s);
        }
    }

    public class StringSet : IEnumerable<string>
    {
        private List<string> _items = new List<string>();

        public void Add(string value)
        {
            _items.Add(value);
        }

        public IEnumerator<string> GetEnumerator()
        {
            try
            {
                for (int index = 0; index < _items.Count; index++)
                {
                    yield return _items[index];
                }
            }
            finally
            {
                Console.WriteLine("In iterator finally block");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}