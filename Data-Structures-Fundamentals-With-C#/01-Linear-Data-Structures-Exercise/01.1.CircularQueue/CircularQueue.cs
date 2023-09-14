namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] elements;
        private int startIndex;
        private int endIndex;

        public CircularQueue(int capacity = 4)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Collection contains no elements!");
            }

            T element = this.elements[this.startIndex];
            this.startIndex = (this.startIndex + 1) % this.elements.Length;
            this.Count--;

            return element;
        }

        public void Enqueue(T item)
        {
            if (this.Count == this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.endIndex] = item;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Collection contains no elements!");
            }

            T value = this.elements[this.startIndex];

            return value;
        }

        public T[] ToArray()
        {
            T[] arr = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                arr[i] = this.elements[(this.startIndex + i) % this.elements.Length];
            }

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.elements[(this.startIndex + i) % this.elements.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void Grow()
        {
            this.elements = this.CopyElements();
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private T[] CopyElements()
        {
            T[] newArr = new T[this.elements.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                newArr[i] = this.elements[(this.startIndex + i) % this.elements.Length];
            }

            return newArr;
        }
    }

}
