using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T05._Nether_Realms___Retake
{
    public class Demon
    {
        public Demon(int health, double damage)
        {
            this.Health = health;
            this.Damage = damage;
        }

        public int Health { get; set; }

        public double Damage { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] demonNames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            // Name -> (Health(Key), Damage(Value))
            Dictionary<string, Demon> allDemonsInfo = new Dictionary<string, Demon>();

            string patternToSum = @"[+-]*?\d+[\.\d+]*";
            string patternToMultiplyOrDivide = @"[\*\/]";

            foreach (string demon in demonNames)
            {
                int health = GetTotalHealth(demon);

                double totalSum = 0;
                MatchCollection matchesToSum = Regex.Matches(demon, patternToSum);
                foreach (Match match in matchesToSum)
                {
                    totalSum += double.Parse(match.Value);
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

                allDemonsInfo[demon] = new Demon(health, totalSum);
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
