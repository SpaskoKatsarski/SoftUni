using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp
{
    public class MyQueue
    {
        private const int InitialCapacity = 4;

        private const int FirstElementIndex = 0;

        private int[] items;

        public int Count { get; private set; }

        public MyQueue()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }

        //Public methods:
        public void Enqueue(int element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public int Dequeue()
        {
            //1 2 3 4 5
            //Count = 5
            int removedElement = this.items[FirstElementIndex];
            //1
            this.Count--;
            //Count = 4
            this.ShiftLeft();

            return removedElement;
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new ArgumentOutOfRangeException("The MyQueue is empty");
            }

            return this.items[FirstElementIndex];
        }

        public void Clear()
        {
            if (IsEmpty())
            {
                throw new ArgumentOutOfRangeException("The MyQueue is empty");
            }

            for (int i = 0; i < this.Count; i++)
            {
                this.items[i] = 0;
            }
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

        //Private methods:
        private void Resize()
        {
            var copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void ShiftLeft()
        {
            //1 2 3 4 5
            //Count = 4
            //max i = 4
            for (int i = 0; i < this.Count; i++)
            {
                //i = 0 -> 2 2 3 4 5 0 0
                //i = 1 -> 2 3 3 4 5 0 0
                //i = 2 -> 2 3 4 4 5 0 0
                //i = 3 -> 2 3 4 5 5 0 0
                //i = 4 -> 2 3 4 5 0 0 0
                //Done
                this.items[i] = this.items[i + 1];
            }

            //for (int i = 1; i < this.Count - 1; i++)
            //{
            //    this.items[i - 1] = this.items[i];
            //}

            //this.items[this.Count - 1] = default;
        }

        private bool IsEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}
