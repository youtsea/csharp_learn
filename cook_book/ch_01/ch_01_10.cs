using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//普通类型和泛型
namespace cook_book.ch_01
{
    class ch_01_10
    {
    }

    public class FixedSizeCollection
    {
        public FixedSizeCollection(int maxItems)
        {
            FixedSizeCollection.InstanceCount ++;
            this.Items = new object[maxItems];
        }

        public int AddItem(object item)
        {
            if (this.ItemCount < this.Items.Length)
            {
                this.Items[this.ItemCount] = item;
                return this.ItemCount++;
            }
            else
            {
                throw new Exception("Item queue is full");
            }
        }

        public object GetItem(int index)
        {
            if (index >= this.Items.Length && index >= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return this.Items[index];
        }

        public static int InstanceCount { get; set; }
        public int ItemCount { get; private set; }
        private object[] Items { get; set; }

        public override string ToString() =>
            $"There are {FixedSizeCollection.InstanceCount.ToString()} instances of {this.GetType().ToString()} and this instance contains {this.ItemCount} items...";
    }

    public class FixedSizeCollectionGeneric<T>
    {
        public FixedSizeCollectionGeneric(int items)
        {
            FixedSizeCollectionGeneric<T>.InstanceCount++;
            this.Items = new T[items];
        }

        public int AddItem(T item)
        {
            if (this.ItemCount < this.Items.Length)
            {
                this.Items[this.ItemCount] = item;
                return this.ItemCount++;
            }
            else
            {
                throw new Exception("Item queue is full");
            }
        }

        public T GetItem(int index)
        {
            if (index >= this.Items.Length && index >= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return this.Items[index];
        }

        public static int InstanceCount { get; set; }
        public int ItemCount { get; private set; }
        private T[] Items { get; set; }

        public override string ToString() =>
            $"There are {FixedSizeCollectionGeneric<T>.InstanceCount.ToString()} instances of {this.GetType().ToString()} and this instance contains {this.ItemCount} items...";
    }
}