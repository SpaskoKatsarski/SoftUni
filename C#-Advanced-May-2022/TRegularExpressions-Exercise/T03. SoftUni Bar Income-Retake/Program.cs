using System;
using System.Text.RegularExpressions;

namespace T03._SoftUni_Bar_Income_Retake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern =
                @"^%(?<customer>[A-Z][a-z]+)%[^\|\$\%\,\.]*?<(?<product>\w+)>[^\|\$\%\,\.]*?\|(?<count>\d+)\|[^\|\$\%\,\.]*?(?<price>[-+]?\d+[\.\d+]*?)\$";

            // ^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+)\$

            decimal totalPrice = 0m;

            string input = Console.ReadLine();
            while (input != "end of shift")
            {
                Match orderInfo = Regex.Match(input, pattern);

                if (orderInfo.Success)
                {
                    PrintOrderInfo(orderInfo, ref totalPrice);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalPrice:f2}");
        }

        static void PrintOrderInfo(Match orderInfo, ref decimal totalPrice)
        {
            decimal currTotal = int.Parse(orderInfo.Groups["count"].Value) *
                                decimal.Parse(orderInfo.Groups["price"].Value);
            totalPrice += currTotal;

            Console.WriteLine($"{orderInfo.Groups["customer"].Value}: {orderInfo.Groups["product"].Value} - {currTotal:f2}");
        }
    }
}
