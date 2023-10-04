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
            CookiesProblem cookiesP = new CookiesProblem();
            Console.WriteLine(cookiesP.Solve(7, new int[] { 12, 3, 9, 10, 2 }));
        }
    }
}
