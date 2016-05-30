using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//实现可搜索类型
namespace cook_book.ch_01
{
    class ch_01_03
    {
        public static void TestSearch()
        {
            List<Square> listOfSquares = new List<Square>
            {
                new Square(1, 3),
                new Square(4, 3),
                new Square(2, 1),
                new Square(6, 1)
            };

            IComparer<Square> heigComparer = new CompareHeight();

            Console.WriteLine("list<Square>");
            Console.WriteLine("Original list");

            foreach (var square in listOfSquares)
            {
                Console.WriteLine(square.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Search using IComparer<Square>=heightCompare");
            int found = listOfSquares.BinarySearch(new Square(1, 3), heigComparer);
            Console.WriteLine($"Found (1,3): {found}");

            Console.WriteLine();
            Console.WriteLine("Sorted list using IComparable<Square>");
            listOfSquares.Sort();
            foreach (var square in listOfSquares)
            {
                Console.WriteLine(square.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Search using IComparable<Square>");
            found = listOfSquares.BinarySearch(new Square(6, 1));
            Console.WriteLine($"Fonud (6,1): {found}");

            var sortedListOfSquares = new SortedList<int, Square>()
            {
                {0, new Square(1, 3)},
                {2, new Square(4, 3)},
                {1, new Square(2, 1)},
                {4, new Square(6, 1)}
            };

            Console.WriteLine();
            Console.WriteLine("SortedList<Square>");
            foreach (KeyValuePair<int,Square> kvp in sortedListOfSquares)
            {
                Console.WriteLine($"{kvp.Key} : {kvp.Value}");
            }

            Console.WriteLine();
            bool foundItem = sortedListOfSquares.ContainsKey(2);
            Console.WriteLine($"sortedListOfSquares.ContainsKey(2): {foundItem}");
            Console.WriteLine();

            Square value = new Square(6,1);
            foundItem = sortedListOfSquares.ContainsValue(value);
            Console.WriteLine("sortedListOfSquares.ContainsValue" + $"new Square(6,1): {foundItem}");
        }
    }
}