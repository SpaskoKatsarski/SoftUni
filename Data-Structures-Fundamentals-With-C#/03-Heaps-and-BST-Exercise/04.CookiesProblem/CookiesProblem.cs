using System;
using System.Collections.Generic;
using System.Linq;
using _03.MinHeap;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            MinHeap<int> minHeap = new MinHeap<int>();

            foreach (var cookie in cookies)
            {
                minHeap.Add(cookie);
            }

            int currentMinSweetness = minHeap.Peek();
            int steps = 0;

            while (currentMinSweetness < minSweetness && minHeap.Size > 1)
            {
                int leastSweetCookie = minHeap.ExtractMin();
                int secondLeastSweetCookie = minHeap.ExtractMin();

                int mixed = leastSweetCookie + 2 * secondLeastSweetCookie;

                minHeap.Add(mixed);

                currentMinSweetness = minHeap.Peek();
                steps++;
            }

            return currentMinSweetness < minSweetness ? -1 : steps;
        }
    }
}
