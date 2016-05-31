using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//list保持有序
namespace cook_book.ch_02
{
    class ch_02_02
    {
        public static void Test()
        {
            SortedList<int> sortedList = new SortedList<int>();
            sortedList.Add(200);
            sortedList.Add(20);
            sortedList.Add(2);
            sortedList.Add(7);
            sortedList.Add(10);
            sortedList.Add(0);
            sortedList.Add(100);
            sortedList.Add(-20);
            sortedList.Add(56);
            sortedList.Add(55);
            sortedList.Add(57);
            sortedList.Add(200);
            sortedList.Add(-2);
            sortedList.Add(-20);
            sortedList.Add(55);
            sortedList.Add(55);

            foreach (var i in sortedList)
            {
                Console.WriteLine(i);
            }

            sortedList.ModifySorted(0, 5);
            sortedList.ModifySorted(1, 10);
            sortedList.ModifySorted(2, 11);
            sortedList.ModifySorted(3, 7);
            sortedList.ModifySorted(4, 2);
            sortedList.ModifySorted(2, 4);
            sortedList.ModifySorted(15, 0);
            sortedList.ModifySorted(0, 15);
            sortedList.ModifySorted(223, 15);

            Console.WriteLine();
            foreach (var i in sortedList)
            {
                Console.WriteLine(i);
            }
        }
    }

    public class SortedList<T> : List<T>
    {
        public new void Add(T item)
        {
            int position = this.BinarySearch(item);
            if (position < 0)
            {
                position = ~position;
            }
            this.Insert(position, item);
        }

        public void ModifySorted(T item, int index)
        {
            this.RemoveAt(index);

            int position = this.BinarySearch(item);
            if (position < 0)
            {
                position = ~position;
            }
            this.Insert(position, item);
        }
    }
}
