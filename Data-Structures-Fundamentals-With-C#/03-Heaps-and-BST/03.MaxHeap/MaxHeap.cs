namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);

            this.HeapifyUp(this.Size - 1);
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = this.GetParentIndex(index);

            while (index > 0 && this.IsGreater(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            T parentTemp = this.elements[parentIndex];
            this.elements[parentIndex] = this.elements[index];
            this.elements[index] = parentTemp;
        }

        private bool IsGreater(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) > 0;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        public T ExtractMax()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            T maxElement = this.elements[0];
            this.Swap(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);

            this.HeapifyDown(0);

            return maxElement;
        }

        private void HeapifyDown(int index)
        {
            int biggerChild = this.GetBiggerChildIndex(index);

            while (this.IsIndexValid(biggerChild) && this.IsGreater(biggerChild, index))
            {
                this.Swap(biggerChild, index);
                index = biggerChild;
                biggerChild = this.GetBiggerChildIndex(index);
            }
        }

        private bool IsIndexValid(int index)
        {
            return index >= 0 && index < this.Size;
        }

        private int GetBiggerChildIndex(int index)
        {
            int leftChild = index * 2 + 1;
            int rightChild = index * 2 + 2;

            if (rightChild < this.Size)
            {
                if (this.IsGreater(leftChild, rightChild))
                {
                    return leftChild;
                }

                return rightChild;
            }
            else if (leftChild < this.Size)
            {
                return leftChild;
            }

            return -1;
        }

        public T Peek()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements!");
            }

            return this.elements[0];
        }
    }
}
