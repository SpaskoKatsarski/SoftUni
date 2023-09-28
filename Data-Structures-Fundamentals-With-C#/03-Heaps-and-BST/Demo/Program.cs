using System;
using System.Diagnostics.CodeAnalysis;
using _02.BinarySearchTree;
using _03.MaxHeap;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();

            maxHeap.Add(9);
            maxHeap.Add(12);
            maxHeap.Add(10);
            maxHeap.Add(15);
            maxHeap.Add(20);
            maxHeap.Add(7);
            maxHeap.Add(14);

            Console.WriteLine(maxHeap.ExtractMax());
            Console.WriteLine(maxHeap.ExtractMax());
            Console.WriteLine(maxHeap.ExtractMax());
        }
    }
}