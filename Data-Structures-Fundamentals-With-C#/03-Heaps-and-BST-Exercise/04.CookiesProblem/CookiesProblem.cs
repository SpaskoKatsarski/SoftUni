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
            OrderedBag<int> priorityQueue = new OrderedBag<int>();
            priorityQueue.AddMany(cookies);

            int currentMinSweetness = priorityQueue[0];
            int steps = 0;

            while (currentMinSweetness < minSweetness && priorityQueue.Count > 0)
            {
                int leastSweetCookie = priorityQueue.RemoveFirst();
                int secondLeastSweetCookie = priorityQueue.RemoveFirst();

                int mixed = leastSweetCookie + 2 * secondLeastSweetCookie;

                priorityQueue.Add(mixed);

                currentMinSweetness = priorityQueue[0];
                steps++;
            }

            return currentMinSweetness < minSweetness ? -1 : steps;
        }
    }
}
