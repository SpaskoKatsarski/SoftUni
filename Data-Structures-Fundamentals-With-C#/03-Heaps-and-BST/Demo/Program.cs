using System;
using _01.BinaryTree;
using _02.BinarySearchTree;
using _03.MaxHeap;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Insert(17);
            tree.Insert(25);
            tree.Insert(9);
            tree.Insert(3);
            tree.Insert(11);
            tree.Insert(20);
            tree.Insert(31);

            tree.Insert(24);

            IBinarySearchTree<int> newTree = tree.Search(9);

            newTree.EachInOrder(Console.WriteLine);
        }
    }
}