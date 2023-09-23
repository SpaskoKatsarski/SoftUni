﻿namespace TreeFactory
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

            this.PathsSum(this, currentSum, sum, stack, ref result);

            return result;
        }
        
        private void PathsSum(IntegerTree tree, int currentSum, int sum, List<int> pathsCollection, ref List<List<int>> result)
        {
            pathsCollection.Add(tree.Key);

            foreach (IntegerTree child in tree.Children)
            {
                // ref currentSum + tree.Key
                this.PathsSum(child, currentSum + tree.Key, sum, pathsCollection, ref result);
                // Parent
                pathsCollection.Remove(child.Key);
            }

            if (tree.Children.Count == 0)
            {
                currentSum += tree.Key;

                if (currentSum == sum)
                {
                    result.Add(pathsCollection.ToList());
                }
            }
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }
    }
}
