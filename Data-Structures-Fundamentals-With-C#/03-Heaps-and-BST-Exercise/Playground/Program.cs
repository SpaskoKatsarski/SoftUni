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
            MinHeap<int> minHeap = new MinHeap<int>();
            minHeap.Add(3);
            minHeap.Add(2);
            minHeap.Add(1);

            Console.WriteLine(minHeap.ExtractMin());
            Console.WriteLine(minHeap.ExtractMin());
            Console.WriteLine(minHeap.ExtractMin());
            Console.WriteLine(minHeap.Size == 0);
        }
    }
}
