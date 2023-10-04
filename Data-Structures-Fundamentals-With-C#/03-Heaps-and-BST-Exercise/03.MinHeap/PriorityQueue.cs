using System;
using System.Collections.Generic;

namespace _03.MinHeap
{
    public class PriorityQueue<T> : MinHeap<T> where T : IComparable<T>
    {
        public PriorityQueue()
        {
            this.elements = new List<T>();
        }

        public void Enqueue(T element)
        {
            this.elements.Add(element);
            base.HeapifyUp(this.elements.Count - 1);
        }

        public T Dequeue()
        {
            T element = base.ExtractMin();

            return element;
        }

        public void DecreaseKey(T key)
        {
            int index = this.elements.IndexOf(key);
            base.HeapifyUp(index);
        }

        public void DecreaseKey(T key, T newKey)
        {
            int oldIndex = this.elements.IndexOf(key);
            this.elements[oldIndex] = newKey;

            this.HeapifyUp(oldIndex);
        }
    }
}
