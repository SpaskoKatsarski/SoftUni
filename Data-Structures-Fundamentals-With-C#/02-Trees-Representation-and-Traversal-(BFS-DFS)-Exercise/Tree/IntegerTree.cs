namespace TreeFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }
        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            List<List<int>> result = new List<List<int>>();

            int currentSum = 0;
            List<int> stack = new List<int>();

            this.PathsSum(this, currentSum, sum, stack, result);

            return result;
        }

        private void PathsSum(IntegerTree tree, int currentSum, int sum, List<int> pathsCollection, List<List<int>> result)
        {
            pathsCollection.Add(tree.Key);

            foreach (IntegerTree child in tree.Children)
            {
                this.PathsSum(child, currentSum + tree.Key, sum, pathsCollection, result);
                // Parent
                pathsCollection.Remove(child.Key);
            }

            if (tree.Children.Count == 0)
            {
                // Leaf
                currentSum += tree.Key;

                if (currentSum == sum)
                {
                    result.Add(pathsCollection.ToList());
                }
            }
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            List<List<Tree<int>>> result = new List<List<Tree<int>>>(); // (1, 2, 3), (4, 0, 1), ...
            
            Queue<IntegerTree> queue = new Queue<IntegerTree>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                List<Tree<int>> currentPath = new List<Tree<int>>();
                
                IntegerTree tree = queue.Dequeue();
                currentPath.Add(tree);

                foreach (IntegerTree child in tree.Children)
                {
                    queue.Enqueue(child);
                    currentPath.Add(child);
                }

                if (currentPath.Sum(t => t.Key) == sum)
                {
                    result.Add(currentPath);
                }
            }

            List<Tree<int>> newResult = new List<Tree<int>>();

            foreach (var subtreeList in result)
            {
                foreach (var node in subtreeList)
                {
                    newResult.Add(node);
                }
            }

            return newResult;
        }
    }
}