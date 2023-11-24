using System;
using AVLTree;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            var tree = new AVL<int>();

            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(10);

            Console.WriteLine(tree.Contains(5));
            Console.WriteLine(tree.Contains(30));
            Console.WriteLine(tree.Contains(50));
            Console.WriteLine(tree.Contains(10));
        }
    }
}
