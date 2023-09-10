namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
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

        private Node head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            Node node = this.head;

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

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            T firstNodeValue = this.head.Value;
            this.head = this.head.Next;

            this.Count--;
            return firstNodeValue;
        }

        public void Enqueue(T item)
        {
            if (this.head == null)
            {
                this.head = new Node(item);
            }
            else
            {
                Node node = this.head;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = new Node(item);
            }

            this.Count++;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            return this.head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = this.head;

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