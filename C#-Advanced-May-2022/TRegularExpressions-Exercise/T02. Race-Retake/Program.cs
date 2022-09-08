using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T02._Race_Retake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] validNames = Console.ReadLine()
                .Split(", ");

            Dictionary<string, int> competitorsAndTheirDistance = new Dictionary<string, int>();

            foreach (var name in validNames)
            {
                competitorsAndTheirDistance.Add(name, 0);
            }

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                StringBuilder currName = new StringBuilder();
                int distance = 0;

                foreach (char ch in input)
                {
                    if (Char.IsLetter(ch))
                    {
                        currName.Append(ch);
                    }
                    else if (Char.IsDigit(ch))
                    {
                        distance += ch - 48;
                    }
                }

                if (competitorsAndTheirDistance.ContainsKey(currName.ToString()))
                {
                    competitorsAndTheirDistance[currName.ToString()] += distance;
                }
            }

            int count = 1;
            foreach (var item in competitorsAndTheirDistance.OrderByDescending(x => x.Value))
            {
                string place = count == 1 ? "st" : count == 2 ? "nd" : "rd";
                Console.WriteLine($"{count}{place} place: {item.Key}");

                count++;

                if (count == 4)
                {
                    break;
                }
            }
        }
    }
}
