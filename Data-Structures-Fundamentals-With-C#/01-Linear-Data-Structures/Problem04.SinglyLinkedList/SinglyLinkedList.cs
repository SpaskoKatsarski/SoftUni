namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

        public void AddFirst(T item)
        {
            if (this.head == null)
            {
                this.head = new Node(item);
            }
            else
            {
                Node currFirst = this.head;
                this.head = new Node(item, currFirst);
            }

            this.Count++;
        }

        public void AddLast(T item)
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

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("There are no elements in the collection!");
            }

            return this.head.Value;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("There are no elements in the collection!");
            }

            Node node = this.head;

            while (node.Next != null)
            {
                node = node.Next;
            }

            return node.Value;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("There are no elements in the collection!");
            }

            Node currFirst = this.head;
            this.head = currFirst.Next;

            this.Count--;
            return currFirst.Value;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("There are no elements in the collection!");
            }

            if (this.Count == 1)
            {
                T value = this.head.Value;
                this.head = null;

                this.Count--;

                return value;
            }

            Node node = this.head;

            while (true)
            {
                if (node.Next.Next == null)
                {
                    T value = node.Next.Value;
                    node.Next = null;
                    this.Count--;

                    return value;
                }

                node = node.Next;
            }
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