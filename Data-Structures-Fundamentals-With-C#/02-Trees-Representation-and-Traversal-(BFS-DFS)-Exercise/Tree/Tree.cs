namespace TreeFactory
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
            child.Parent = this;
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
            parent.children.Add(this);
        }

        public string AsString()
        {
            int indent = 0;
            StringBuilder sb = new StringBuilder();

            this.DfsAsString(sb, indent, this);

            return sb.ToString().Trim();
        }

        private void DfsAsString(StringBuilder sb, int indent, Tree<T> node)
        {
            sb.Append(' ', indent);
            sb.AppendLine(node.Key.ToString());

            foreach (var child in node.children)
            {
                this.DfsAsString(sb, indent + 2, child);
            }
        }

        public IEnumerable<T> GetInternalKeys()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<T> result = new List<T>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> currNode = queue.Dequeue();

                if (currNode.Parent != null && currNode.Children.Count > 0)
                {
                    result.Add(currNode.Key);
                }

                foreach (var child in currNode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            result.Reverse();
            return result;
        }

        //public string Bfs()
        //{
        //    Queue<Tree<T>> queue = new Queue<Tree<T>>();
        //    List<T> result = new List<T>();

        //    queue.Enqueue(this);

        //    while (queue.Count > 0)
        //    {
        //        var curr = queue.Dequeue();

        //        foreach (var item in curr.children)
        //        {
        //            queue.Enqueue(item);
        //        }

        //        result.Add(curr.Key);
        //    }

        //    return string.Join(", ", result);
        //}

        public IEnumerable<T> GetLeafKeys()
        {
            List<T> result = new List<T>();
            this.Dfs(this, result);
            return result;
        }

        private void Dfs(Tree<T> node, ICollection<T> collection)
        {
            foreach (var child in node.Children)
            {
                this.Dfs(child, collection);
            }

            if (node.Children.Count == 0)
            {
                collection.Add(node.Key);
            }
        }

        public IEnumerable<T> GetLeafKeysBfs()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<T> result = new List<T>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> currNode = queue.Dequeue();

                if (currNode.Children.Count == 0)
                {
                    result.Add(currNode.Key);
                }

                foreach (var child in currNode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public T GetDeepestKey()
        {
            int maxDepth = 0;
            Tree<T> deepestNode = null;

            int currDepth = 0;

            this.DeepestKeyDfs(currDepth, this, ref maxDepth, ref deepestNode);

            return deepestNode.Key;
        }

        private void DeepestKeyDfs(int depth, Tree<T> tree, ref int maxDepth, ref Tree<T> deepestNode)
        {
            foreach (var child in tree.Children)
            {
                this.DeepestKeyDfs(depth + 1, child, ref maxDepth, ref deepestNode);
            }

            if (depth > maxDepth)
            {
                maxDepth = depth;
                deepestNode = tree;
            }
        }

        public IEnumerable<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }
    }
}