using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp
{
    public class MyList<T>
    {
        private const int InitialCapacity = 2;

        private T[] items;

        public MyList()
        {
            items = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index >= this.Count)
                    throw new ArgumentOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index >= this.Count)
                    throw new ArgumentOutOfRangeException();

                items[index] = value;
            }
        }

        //Public methods:
        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                //We need recizing:
                this.Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public T RemoveAt(int index)
        {
            if (!IsIndexValid(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            T removedItem = this.items[index];
            this.items[index] = default;

            this.Shift(index);
            this.Count--;

            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink(index);
            }

            return removedItem;
        }

        public void Insert(int index, T value)
        {
            if (!IsIndexValid(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.Count++;
            this.ShiftRight(index);
            this.items[index] = value;
        }

        //public bool Contains(int element)
        //{
        //    foreach (var item in items)
        //    {
        //        if (item == element)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        public void Swap(int firstIndex, int secondIndex)
        {
            if (!IsIndexValid(firstIndex) || !IsIndexValid(secondIndex))
            {
                throw new ArgumentOutOfRangeException();
            }

            var firstElement = this.items[firstIndex];

            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = firstElement;
        }
        
        public T Find(Predicate<T> predicate)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (predicate(this.items[i]))
                {
                    return this.items[i];
                }
            }

            return default;
        }


        //Private methods:
        private void Resize()
        {
            var copy = new T[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }

            this.items = copy;
        }

        private bool IsIndexValid(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                return false;
            }

            return true;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void Shrink(int index)
        {
            var copy = new T[items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = items[i];
            }

            this.items = copy;
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count - 1; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        public override string ToString()
        {
            return string.Join(", ", items.Where(x => x != null));
        }
    }
}
