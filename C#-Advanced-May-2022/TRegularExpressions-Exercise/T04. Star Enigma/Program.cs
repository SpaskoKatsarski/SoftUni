using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            string pattern =
                @"\@(?<planet>[A-Za-z]+)[^\@\=\!\:\>]*?:\d+[^\@\=\!\:\>]*?!(?<typeOfAttack>A|D){1}![^\@\=\!\:\>]*?->\d+[^\@\=\!\:\>]*?";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();

                string decryptMessage = DecryptMessage(encryptedMessage);

                Match planetInfo = Regex.Match(decryptMessage, pattern);

                if (planetInfo.Success)
                {
                    string attackType = planetInfo.Groups["typeOfAttack"].Value;
                    string planet = planetInfo.Groups["planet"].Value;

                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planet);
                    }
                    else if (attackType == "D")
                    {
                        destroyedPlanets.Add(planet);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planet in attackedPlanets.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planet in destroyedPlanets.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }
        }

        public static string DecryptMessage(string encryptedMessage)
        {
            int key = GetSubstractionKey(encryptedMessage);
            StringBuilder decryptedMessage = new StringBuilder();

            foreach (char ch in encryptedMessage)
            {
                char newChar = (char)(ch - key);

                decryptedMessage.Append(newChar);
            }

            return decryptedMessage.ToString();
        }

        public static int GetSubstractionKey(string decryptedMessage)
        {
            string pattern = @"[star]{1}";

            MatchCollection matches = Regex.Matches(decryptedMessage, pattern, RegexOptions.IgnoreCase);

            return matches.Count;
        }
    }
}
