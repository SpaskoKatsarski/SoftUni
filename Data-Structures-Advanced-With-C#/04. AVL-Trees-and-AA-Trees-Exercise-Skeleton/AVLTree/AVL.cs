namespace AVLTree
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public class Node
        {
            private const int DefaultHeight = 1;

            public Node(T value)
            {
                this.Value = value;
                this.Height = DefaultHeight;
            }

            public T Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public int Height { get; set; }

            public override string ToString()
            {
                return this.Value.ToString();
            }
        }

        public Node Root { get; private set; }

        public bool Contains(T element)
        {
            return this.Contains(this.Root, element);
        }

        private bool Contains(Node node, T element)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value.Equals(element))
            {
                return true;
            }

            if (element.CompareTo(node.Value) > 0)
            {
                return this.Contains(node.Right, element);
            }

            return this.Contains(node.Left, element);
        }

        public void Delete(T element)
        {
            this.Root = this.Delete(this.Root, element);
        }

        private Node Delete(Node node, T element)
        {
            if (node == null)
            {
                return null;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Delete(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Delete(node.Right, element);
            }
            else
            {
                if (node.Left == null && node.Right == null)
                {
                    return null;
                }
                else if (node.Left == null)
                {
                    node = node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                else
                {
                    Node temp = this.FindSmallestChild(node.Right);
                    node.Value = temp.Value;

                    node.Right = this.Delete(node.Right, temp.Value);
                }
            }

            node = this.Balance(node);
            node.Height = Math.Max(this.GetHeight(node.Left), this.GetHeight(node.Right)) + 1;

            return node;
        }

        private Node FindSmallestChild(Node node)
        {
            //if (node == null)
            //{
            //    return node;
            //}

            if (node.Left == null)
            {
                return node;
            }

            return this.FindSmallestChild(node.Left);
        }

        public void DeleteMin()
        {
            if (this.Root == null)
            {
                return;
            }

            Node smallestNode = this.FindSmallestChild(this.Root);
            this.Delete(smallestNode.Value);
        }

        public void Insert(T element)
        {
            this.Root = this.Insert(this.Root, element);
        }

        private Node Insert(Node node, T element)
        {
            if (node == null)
            {
                return new Node(element);
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(node.Left, element);
            }
            else
            {
                node.Right = this.Insert(node.Right, element);
            }

            node = this.Balance(node);
            node.Height = Math.Max(this.GetHeight(node.Left), this.GetHeight(node.Right)) + 1;

            return node;
        }

        private int GetHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private Node Balance(Node node)
        {
            int balanceFactor = this.GetBalanceFactor(node); // Correct if it is in range: -1, 0, 1

            if (balanceFactor > 1)
            {
                int leftChildBalanceFactor = this.GetBalanceFactor(node.Left);

                if (leftChildBalanceFactor < 0)
                {
                    // Double Right Rotation
                    node.Left = this.RotateLeft(node.Left);
                }

                node = this.RotateRight(node);
            }
            else if (balanceFactor < -1)
            {
                int rightChildBalanceFactor = this.GetBalanceFactor(node.Right);

                if (rightChildBalanceFactor > 0)
                {
                    // Double Left Rotation
                    node.Right = this.RotateRight(node.Right);
                }

                node = this.RotateLeft(node);
            }

            return node;
        }

        private int GetBalanceFactor(Node node)
        {
            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        private Node RotateRight(Node node)
        {
            Node left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;

            return left;
        }

        private Node RotateLeft(Node node)
        {
            Node right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;

            return right;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.Root, action);
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action.Invoke(node.Value);
            this.EachInOrder(node.Right, action);
        }
    }
}
