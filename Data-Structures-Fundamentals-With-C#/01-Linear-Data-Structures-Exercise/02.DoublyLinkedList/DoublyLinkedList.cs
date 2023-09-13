namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node(T value)
                : this(value, null, null)
            {
                
            }

            public Node(T value, Node next, Node previous)
            {
                this.Value = value;
                this.Next = next;
                this.Previous = previous;
            }

            public Node Next { get; set; }

            public Node Previous { get; set; }

            public T Value { get; set; }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new Node(item);
            }
            else
            {
                Node currHead = this.head;

                this.head = new Node(item);
                this.head.Next = currHead;
                currHead.Previous = this.head;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            if (this.Count == 0)
            {
                this.tail = this.head = new Node(item);
            }
            else
            {
                Node currTail = this.tail;

                this.tail = new Node(item);
                this.tail.Previous = currTail;
                currTail.Next = this.tail;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Collection contains no elements!");
            }

            return this.head.Value;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Collection contains no elements!");
            }

            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Collection contains no elements!");
            }

            if (this.Count == 1)
            {
                T value = this.head.Value;
                this.head = this.tail = null;

                this.Count--;

                return value;
            }

            Node currHead = this.head;
            this.head = currHead.Next;
            this.head.Previous = null;

            this.Count--;

            return currHead.Value;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Collection contains no elements!");
            }

            if (this.Count == 1)
            {
                T value = this.tail.Value;
                this.head = this.tail = null;

                this.Count--;

                return value;
            }

            Node currTail = this.tail;
            this.tail = currTail.Previous;
            this.tail.Next = null;

            this.Count--;

            return currTail.Value;
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