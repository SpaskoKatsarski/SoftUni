using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace T04._Star_Enigma___Retake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            string pattern = @"[star]";
            string patternForPlanetInfo = @"@(?<planet>[A-Za-z]+)[^\@\-\!\:\>]*?:\d+[^\@\-\!\:\>]*?!(?<attackType>[AD])![^\@\-\!\:\>]*?->\d+";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();

                MatchCollection letterMatches = Regex.Matches(encryptedMessage, pattern, RegexOptions.IgnoreCase);
                int removeKey = letterMatches.Count;

                StringBuilder decryptedMessage = new StringBuilder();

                foreach (char ch in encryptedMessage)
                {
                    decryptedMessage.Append((char)(ch - removeKey));
                }

                Match planetInfo = Regex.Match(decryptedMessage.ToString(), patternForPlanetInfo);

                if (planetInfo.Groups["attackType"].Value == "A")
                {
                    attackedPlanets.Add(planetInfo.Groups["planet"].Value);
                }
                else if (planetInfo.Groups["attackType"].Value == "D")
                {
                    destroyedPlanets.Add(planetInfo.Groups["planet"].Value);
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            if (attackedPlanets.Count > 0)
            {
                foreach (string planet in attackedPlanets.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            if (destroyedPlanets.Count > 0)
            {
                foreach (string planet in destroyedPlanets.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
        }
    }
}
