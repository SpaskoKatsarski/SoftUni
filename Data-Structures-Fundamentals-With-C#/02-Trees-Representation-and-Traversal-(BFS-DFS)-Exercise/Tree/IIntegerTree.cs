using System;
using System.Collections.Generic;

namespace TreeFactory
{
    public interface IIntegerTree: IAbstractTree<int>
    {
        IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum);

        IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum);
    }
}
