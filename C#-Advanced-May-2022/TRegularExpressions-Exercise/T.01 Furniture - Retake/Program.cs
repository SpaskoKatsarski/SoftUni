using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T._01_Furniture___Retake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[\>]{2}(?<name>[A-Za-z\s]+)[\<]{2}(?<price>\d+(\.\d+)?)!(?<quantity>\d+)";
            List<string> boughtFurniture = new List<string>();
            decimal totalSum = 0m;

            string command;
            while ((command = Console.ReadLine()) != "Purchase")
            {
                Match furnitureInfo = Regex.Match(command, pattern);

                if (furnitureInfo.Success)
                {
                    string name = furnitureInfo.Groups["name"].Value;
                    decimal totalPrice =  decimal.Parse(furnitureInfo.Groups["price"].Value) * int.Parse(furnitureInfo.Groups["quantity"].Value);

                    boughtFurniture.Add(name);
                    totalSum += totalPrice;
                }
            }

            Console.WriteLine("Bought furniture:");
            if (boughtFurniture.Count > 0)
            {
                foreach (string furniture in boughtFurniture)
                {
                    Console.WriteLine(furniture);
                }
            }

            Console.WriteLine($"Total money spend: {totalSum:f2}");
        }
    }
}
