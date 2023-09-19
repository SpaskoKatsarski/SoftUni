namespace Tree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;
        private T value;
        private Tree<T> parent;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> parent = this.FindNodeWithBfs(parentKey);

            if (parent == null)
            {
                throw new ArgumentNullException(nameof(parentKey));
            }

            parent.children.Add(child);
            child.parent = parent;
        }

        private Tree<T> FindNodeWithBfs(T key)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> node = queue.Dequeue();

                if (node.value.Equals(key))
                {
                    return node;
                }

                foreach (var child in node.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private Tree<T> FindNodeWithDfs(T key)
        {
            Stack<Tree<T>> stack = new Stack<Tree<T>>();

            stack.Push(this);

            while (stack.Count > 0)
            {
                Tree<T> node = stack.Pop();

                foreach (var child in node.children)
                {
                    stack.Push(child);
                }

                if (node.value.Equals(key))
                {
                    return node;
                }
            }

            return null;
        }

        public IEnumerable<T> OrderBfs()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<T> result = new List<T>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> currentNode = queue.Dequeue();

                result.Add(currentNode.value);

                foreach (var child in currentNode.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            Stack<T> result = new Stack<T>();
            Stack<Tree<T>> stack = new Stack<Tree<T>>();

            stack.Push(this);

            while (stack.Count > 0)
            {
                Tree<T> node = stack.Pop();

                foreach (var child in node.children)
                {
                    stack.Push(child);
                }

                result.Push(node.value);
            }

            return result;
        }

        public IEnumerable<T> OrderDfs2()
        {
            List<T> result = new List<T>();
            this.Dfs(this, result);
            return result;
        }

        private void Dfs(Tree<T> node, ICollection<T> result)
        {
            foreach (var child in node.children)
            {
                this.Dfs(child, result);
            }

            result.Add(node.value);
        }

        public void DfsWriteOnConsole()
        {
            Tree<T> node = this;
            foreach (var child in node.children)
            {
                child.DfsWriteOnConsole();
            }

            Console.WriteLine(node.value);
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> node = this.FindNodeWithDfs(nodeKey);

            if (node == null)
            {
                throw new ArgumentNullException(nameof(nodeKey));
            }

            if (node.parent == null)
            {
                throw new ArgumentException(nameof(nodeKey));
            }

            Tree<T> parentNode = node.parent;
            parentNode.children.Remove(node);
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstNode = this.FindNodeWithBfs(firstKey);
            Tree<T> secondNode = this.FindNodeWithBfs(secondKey);

            if (firstNode == null || secondNode == null)
            {
                throw new ArgumentNullException();
            }

            Tree<T> firstParent = firstNode.parent;
            Tree<T> secondParent = secondNode.parent;

            if (firstParent == null || secondParent == null)
            {
                throw new ArgumentException();
            }

            int indexOfFirstChild = firstParent.children.IndexOf(firstNode);
            int indexOfSecondChild = secondParent.children.IndexOf(secondNode);

            firstParent.children[indexOfFirstChild] = secondNode;
            secondNode.children[indexOfSecondChild] = firstNode;

            secondNode.parent = firstParent;
            firstNode.parent = secondParent;
    }
}
