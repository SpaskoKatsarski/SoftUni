using System;
using AVLTree;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            var tree = new AVL<int>();

            tree.Insert(10);
            tree.Insert(30);
            tree.Insert(50);

            tree.Delete(30);

            Console.WriteLine($"{tree.Root.Value} - {tree.Root.Height}");
            Console.WriteLine($"{tree.Root.Left.Value} - {tree.Root.Left.Height}");
            Console.WriteLine($"{tree.Root.Right.Value} - {tree.Root.Left.Height}");
        }
    }
}
