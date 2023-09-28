namespace Demo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TreeFactory;

    class Program
    {
        static void Main(string[] args)
        {
            var input = new string[] { "7 19", "7 21", "7 14", "19 1", "19 12", "19 31", "14 23", "14 6" };

            var factory = new TreeFactory();

            var tree = factory.CreateTreeFromStrings(input);

            IEnumerable<Tree<int>> result = tree.GetSubtreesWithGivenSum(43);

            Console.WriteLine(string.Join(", ", result.Select(n => n.Key)));
        }
    }
}