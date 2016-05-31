using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//实现嵌套结构的foreach
namespace cook_book.ch_02
{
    class ch_02_09
    {
    }

    public class Group<T> : IEnumerable<T>
    {
        public Group(string name)
        {
            this.Name = name;
        }

        private List<T> _groupList = new List<T>();
        public string Name { get; set; }
        public int Count => _groupList.Count;

        public void Add(T group)
        {
            _groupList.Add(group);
        }

        public IEnumerator<T> GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _groupList.GetEnumerator();
    }

    public class Item
    {
        public Item(string name, int location)
        {
            this.Name = name;
            this.Location = location;
        }

        public string Name { get; set; }
        public int Location { get; set; }
    }

    public class GroupEnumerator<T> : IEnumerator
    {
        public T[] _items;
        private int position = -1;

        public GroupEnumerator(T[] list)
        {
            _items = list;
        }

        public bool MoveNext()
        {
            position++;
            return position < _items.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _items[position];
                }
                catch (IndexOutOfRangeException)
                {
                    
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
