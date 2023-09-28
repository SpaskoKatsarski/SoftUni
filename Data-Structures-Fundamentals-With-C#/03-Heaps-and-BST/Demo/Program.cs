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

            BinaryTree<int> leftTree = new BinaryTree<int>(4, new BinaryTree<int>(2, null, null), null);
            BinaryTree<int> rightTree = new BinaryTree<int>(10, null, null);
            BinaryTree<int> binaryTree = new BinaryTree<int>(5, leftTree, rightTree);

            binaryTree.ForEachInOrder(Console.WriteLine);
        }
    }
}