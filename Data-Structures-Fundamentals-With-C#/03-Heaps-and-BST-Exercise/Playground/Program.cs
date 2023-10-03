using System;
using System.Collections.Generic;
using _02.BinarySearchTree;
using _03.MinHeap;
using _04.CookiesProblem;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Insert(12);
            binarySearchTree.Insert(5);
            binarySearchTree.Insert(19);
            binarySearchTree.Insert(1);
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(16);
            binarySearchTree.Insert(23);
            binarySearchTree.Insert(21);
            binarySearchTree.Insert(30);

            Console.WriteLine(binarySearchTree.Select(2));
        }
    }
}
