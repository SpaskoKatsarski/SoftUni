using System;
using System.Text.RegularExpressions;

namespace T03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+)\$";
            Regex regex = new Regex(pattern);

            decimal totalPrice = decimal.Zero;

            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                Match currentMatch = regex.Match(input);

                if (currentMatch.Success)
                {
                    decimal currentTotalPrice = int.Parse(currentMatch.Groups["count"].Value) * decimal.Parse(currentMatch.Groups["price"].Value);
                    Console.WriteLine($"{currentMatch.Groups["customer"].Value}: {currentMatch.Groups["product"]} - {currentTotalPrice:f2}");

                    totalPrice += currentTotalPrice;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalPrice:f2}");
        }
    }
}
