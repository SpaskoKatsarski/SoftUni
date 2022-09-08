using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T05._Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] demonNames = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Name -> (Health(Key), Damage(Value))
            Dictionary<string, Dictionary<int, double>> allDemonsInfo = new Dictionary<string, Dictionary<int, double>>();

            string patternToSum = @"[+-]*?\d+[\.\d+]*";
            string patternToMultiplyOrDivide = @"[\*\/]";

            foreach (string demon in demonNames)
            {
                int health = GetTotalHealth(demon);

                double totalSum = 0;
                MatchCollection matchesToSum = Regex.Matches(demon, patternToSum);
                foreach (Match match in matchesToSum)
                {
                    string currentMatch = match.Value;

                    if (currentMatch.Contains("--"))
                    {
                        // -----123.23
                        StringBuilder sb = new StringBuilder('-');
                        foreach (char ch in currentMatch)
                        {
                            if (char.IsDigit(ch))
                            {
                                sb.Append(ch);
                            }
                        }

                        totalSum -= double.Parse(sb.ToString());
                        continue;
                    }

                    totalSum += double.Parse(currentMatch);
                }

                MatchCollection multAndDivideMatches = Regex.Matches(demon, patternToMultiplyOrDivide);

                foreach (Match match in multAndDivideMatches)
                {
                    if (match.Value == "*")
                    {
                        totalSum *= 2;
                    }
                    else
                    {
                        totalSum /= 2;
                    }
                }

                allDemonsInfo[demon] = new Dictionary<int, double>();
                allDemonsInfo[demon].Add(health, totalSum);
            }

            // Malzahar -> 12, 13.5
            // Panda -> 5. 12.1

            foreach (var demon in allDemonsInfo.OrderBy(n => n.Key))
            {
                Console.Write($"{demon.Key} - ");

                foreach (var stats in demon.Value)
                {
                    Console.WriteLine($"{stats.Key} health, {stats.Value:f2} damage");
                }
            }
        }

        public static int GetTotalHealth(string demonName)
        {
            int totalHealth = 0;

            foreach (char symbol in demonName)
            {
                // $, 2, a
                if (char.IsLetter(symbol))
                {
                    totalHealth += symbol;
                }
            }

            return totalHealth;
        }
    }
}
