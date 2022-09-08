using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";

            List<string> items = new List<string>();
            decimal totalPrice = 0m;

            string command;

            while ((command = Console.ReadLine()) != "Purchase")
            {
                Match currMatch = Regex.Match(command, regex);

                if (currMatch.Success)
                {
                    string name = currMatch.Groups["name"].Value;
                    totalPrice += decimal.Parse(currMatch.Groups["price"].Value) * int.Parse(currMatch.Groups["quantity"].Value);

                    items.Add(name);
                }
            }

            Console.WriteLine("Bought furniture:");

            if (items.Count > 0)
            {
                foreach (string furnitureName in items)
                {
                    Console.WriteLine(furnitureName);
                }
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");

            //List<string> furniture = new List<string>();
            //decimal totalPrice = 0m;

            //string command;

            //while ((command = Console.ReadLine()) != "Purchase")
            //{
            //    string namePattern = @"(?<=\>>)(.*?)(?=\<<)";
            //    string pricePattern = @"(?<=\<<)(.*?)(?=\!)"; // Doesn't return the price itself but with '!' at the end.
            //    string quantityPattern = @"[^!]+$";

            //    Match currFurNameMatch = Regex.Match(command, namePattern);
            //    Match currPriceMatch = Regex.Match(command, pricePattern); // Fix this because it returns for example: "32.10!"
            //    Match currQuantity = Regex.Match(command, quantityPattern);

            //    if (currFurNameMatch.Success && currPriceMatch.Success && currQuantity.Success && (!currFurNameMatch.Value.Contains('>') && !currFurNameMatch.Value.Contains('<')) && (!currPriceMatch.Value.Contains('>') && !currPriceMatch.Value.Contains('<')))
            //    {
            //        string currName = currFurNameMatch.Value;

            //        totalPrice += decimal.Parse(currPriceMatch.Value) * decimal.Parse(currQuantity.Value);

            //        furniture.Add(currName);
            //    }
            //}

            //Console.WriteLine("Bought furniture:");

            //foreach (string furnitureName in furniture)
            //{
            //    Console.WriteLine(furnitureName);
            //}

            //Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
