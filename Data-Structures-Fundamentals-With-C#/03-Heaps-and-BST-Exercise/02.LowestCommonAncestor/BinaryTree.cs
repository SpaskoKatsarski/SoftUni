namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            BinaryTree<T> firstNode = this.FindBfs(first, this);
            BinaryTree<T> secondNode = this.FindBfs(second, this);

            if (firstNode == null || secondNode == null)
            {
                throw new InvalidOperationException();
            }

            List<T> firstNodeAncestors = this.FindAncestors(firstNode); 
            List<T> secondNodeAncestors = this.FindAncestors(secondNode);
            
            return firstNodeAncestors.Intersect(secondNodeAncestors).First();
        }

        private List<T> FindAncestors(BinaryTree<T> node)
        {
            List<T> ancestors = new List<T>();
            BinaryTree<T> current = node;

            while (current != null)
            {
                ancestors.Add(current.Value);
                current = current.Parent;
            }

            return ancestors;
        }

        private BinaryTree<T> FindBfs(T value, BinaryTree<T> root)
        {
            Queue<BinaryTree<T>> queue = new Queue<BinaryTree<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                BinaryTree<T> currentNode = queue.Dequeue();

                if (currentNode.Value.Equals(value))
                {
                    return currentNode;
                }

                if (currentNode.LeftChild != null)
                {
                    queue.Enqueue(currentNode.LeftChild);
                }

                if (currentNode.RightChild != null)
                {
                    queue.Enqueue(currentNode.RightChild);
                }
            }

            return null;
        }
    }
}
