namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }

        private Node root;

        public BinarySearchTree() { }

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        private void PreOrderCopy(Node node)
        {
            this.Insert(node.Value);

            if (node.Left != null)
            {
                this.PreOrderCopy(node.Left);
            }

            if (node.Right != null)
            {
                this.PreOrderCopy(node.Right);
            }
        }

        public bool Contains(T element)
        {
            return this.FindNode(element) != null;
        }

        private Node FindNode(T element)
        {
            Node node = this.root;

            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.Left);

            action.Invoke(node.Value);

            this.EachInOrder(action, node.Right);
        }

        public void Insert(T element)
        {
            if (this.root == null)
            {
                this.root = new Node(element);

                return;
            }

            Node node = this.root;
            while (node != null)
            {
                if (node.Value.Equals(element))
                {
                    return;
                }

                if (element.CompareTo(node.Value) > 0)
                {
                    // go right
                    if (node.Right == null)
                    {
                        node.Right = new Node(element);
                        break;
                    }

                    node = node.Right;
                }
                else if (element.CompareTo(node.Value) < 0)
                {
                    // go left
                    if (node.Left == null)
                    {
                        node.Left = new Node(element);
                        break;
                    }

                    node = node.Left;
                }
            }
        }

        public void ReflectionInsert(T element)
        {
            this.root = this.ReflectionInsert(element, this.root);
        }

        private Node ReflectionInsert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.ReflectionInsert(element, node.Right);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.ReflectionInsert(element, node.Left);
            }

            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node node = this.FindNode(element);

            if (node == null)
            {
                return null;
            }

            return new BinarySearchTree<T>(node);
        }
    }
}
