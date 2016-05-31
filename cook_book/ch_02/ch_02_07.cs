using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//支持反向foreach和步长访问的容器类型
namespace cook_book.ch_02
{
    public static class ch_02_07
    {
        public static IEnumerable<T> EveryNthItem<T>(this IEnumerable<T> enumerable, int step)
        {
            int current = 0;
            foreach (T item in enumerable)
            {
                ++current;
                if (current % step == 0)
                    yield return item;
            }
        }
    }

    public class Container<T> : IEnumerable<T>
    {
        public Container()
        {
            
        }

        private List<T> _internalList = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            return _internalList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetReverseOrderEnumerator()
        {
            foreach (T item in ((IEnumerable<T>)_internalList).Reverse())
            {
                yield return item;
            }
        }

        public IEnumerator<T> GetReverseStepEnumerator(int step)
        {
            foreach (T item in ((IEnumerable<T>)_internalList).Reverse().EveryNthItem(step))
            {
                yield return item;
            }
        }

        public IEnumerator<T> GetForwardStepEnumerator(int step)
        {
            foreach (T item in ((IEnumerable<T>)_internalList).EveryNthItem(step))
            {
                yield return item;
            }
        }

        public void Clear()
        {
            _internalList.Clear();
        }

        public void Add(T item)
        {
            _internalList.Add(item);
        }

        public void AddRange(ICollection<T> collection)
        {
            _internalList.AddRange(collection);
        }
    }
}
