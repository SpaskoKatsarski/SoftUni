using System;
using System.Collections.Generic;
using System.Text;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);

            this.HeapifyUp(this.elements.Count - 1);
        }

        public T ExtractMin()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T result = this.elements[0];

            this.elements[0] = this.elements[this.elements.Count - 1];
            this.elements.RemoveAt(this.elements.Count - 1);

            this.HeapifyUp(this.elements.Count - 1);

            return result;
        }

        protected void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (parentIndex >= 0 && this.IsLesser(index, parentIndex))
            {
                this.Swap(index, parentIndex);

                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private bool IsLesser(int index, int parentIndex)
        {
            // If it is smaller a switch should be made
            return this.elements[index].CompareTo(this.elements[parentIndex]) < 0;
        }

        private void Swap(int index, int parentIndex)
        {
            T parentTemp = this.elements[parentIndex];

            this.elements[parentIndex] = this.elements[index];
            this.elements[index] = parentTemp;
        }

        public T Peek()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[0];
        }
    }
}
