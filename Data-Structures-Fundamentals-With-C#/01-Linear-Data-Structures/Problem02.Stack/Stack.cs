namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public Node(T value)
                : this(value, null)
            {
            }

            public Node(T value, Node next)
            {
                this.Value = value;
                this.Next = next;
            }

            public T Value { get; set; }

            public Node Next { get; set; }
        }

        private Node top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node node = this.top;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("There are no elements in the collection!");
            }

            return this.top.Value;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("There are no elements in the collection!");
            }

            T value = this.top.Value;
            this.top = this.top.Next;

            this.Count--;
            return value;
        }

        public void Push(T item)
        {
            if (this.top == null)
            {
                this.top = new Node(item);
            }
            else
            {
                Node node = new Node(item, this.top);
                this.top = node;
            }

            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = this.top;

            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}