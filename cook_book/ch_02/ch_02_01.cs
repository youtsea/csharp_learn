using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

//为list拓展方法
namespace cook_book.ch_02
{
    class ch_02_01
    {
        public static void Test()
        {
            List<int> listRetrieval = new List<int>() {-1, -1, 1, 2, 2, 2, 2, 3, 100, 4, 5};
            Console.WriteLine("--Get All--");
            IEnumerable<int> items = listRetrieval.GetAll(2);
            foreach (var item in items)
            {
                Console.WriteLine($"items: {item}");
            }

            Console.WriteLine();
            items = listRetrieval.GetAll(-2);
            foreach (var item in items)
            {
                Console.WriteLine($"items-2: {item}");
            }

            Console.WriteLine();
            items = listRetrieval.GetAll(5);
            foreach (var item in items)
            {
                Console.WriteLine($"items5: {item}");
            }

            Console.WriteLine("\r\n--BINARY SEARCH GET ALL--");
            listRetrieval.Sort();
            int[] listItems = listRetrieval.BinarySearchGetAll(-2);
            foreach (var item in listItems)
            {
                Console.WriteLine($"items-2: {item}");
            }

            listItems = listRetrieval.BinarySearchGetAll(5);
            foreach (var item in listItems)
            {
                Console.WriteLine($"items5: {item}");
            }

            listItems = listRetrieval.BinarySearchGetAll(2);
            foreach (var item in listItems)
            {
                Console.WriteLine($"items2: {item}");
            }
        }
    }

    public static class CollectionExtMenthods
    {
        public static IEnumerable<T> GetAll<T>(this List<T> myList, T searchValue) =>
            myList.Where(t => t.Equals(searchValue));

        public static T[] BinarySearchGetAll<T>(this List<T> myList, T searchValue)
        {
            List<T> retObjs = new List<T>();
            int center = myList.BinarySearch(searchValue);
            if (center > 0)
            {
                retObjs.Add(myList[center]);

                int left = center;
                while (left > 0 && myList[left - 1].Equals(searchValue))
                {
                    left -= 1;
                    retObjs.Add(myList[left]);
                }
                int right = center;
                while (right < (myList.Count - 1) && myList[right + 1].Equals(searchValue))
                {
                    right += 1;
                    retObjs.Add(myList[right]);
                }
            }

            return retObjs.ToArray();
        }

        public static int CountAll<T>(this List<T> myList, T searchValue) =>
            myList.GetAll(searchValue).Count();

        public static int BinarySearchCountAll<T>(this List<T> myList, T searchValue) =>
            BinarySearchGetAll<T>(myList, searchValue).Count();
    }
}