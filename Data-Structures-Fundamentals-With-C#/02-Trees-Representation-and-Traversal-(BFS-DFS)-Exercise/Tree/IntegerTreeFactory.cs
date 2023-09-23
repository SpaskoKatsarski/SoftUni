namespace TreeFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public IntegerTreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                int[] keys = line.Split(' ').Select(int.Parse).ToArray();
                int parent = keys[0];
                int child = keys[1];

                this.AddEdge(parent, child);
            }

            return this.GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            if (!this.nodesByKey.ContainsKey(key))
            {
                this.nodesByKey.Add(key, new IntegerTree(key));
            }

            return this.nodesByKey[key];
        }

        public void AddEdge(int parent, int child)
        {
            IntegerTree parentNode = this.CreateNodeByKey(parent);
            IntegerTree childNode = this.CreateNodeByKey(child);

            parentNode.AddChild(childNode);
        }

        public IntegerTree GetRoot()
        {
            foreach (var kvp in this.nodesByKey)
            {
                IntegerTree currentNode = kvp.Value;

                if (currentNode.Parent == null)
                {
                    return currentNode;
                }
            }

            return null;
        }
    }
}
