using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp
{
    public class MyStack
    {
        private const int InitialCapacity = 4;

        private int[] items;

        public int Count { get; private set; }

        public MyStack()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }

        //Public methods:
        public int GetPapacity()
        {
            return this.items.Length;
        }

        public void Push(int element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public int Pop()
        {
            if (this.Count == 0)
            {
                throw new ArgumentOutOfRangeException("The MyStack is empty");
            }

            int lastElement = this.items[this.Count - 1];
            MyStack myStack = this; //test example
            myStack.items[this.Count - 1] = default;
            this.Count--;
            return lastElement;
        }

        public int Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentOutOfRangeException("The MyStack is empty");
            }

            return this.items[this.Count - 1];  
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
    }
}
