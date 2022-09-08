using System;
using System.Text.RegularExpressions;

namespace T06._Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Look and understand the following pattern:
            string pattern =
                @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-\_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-][A-Za-z]+)+))(\b|(?=\s))";

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                MatchCollection matches = Regex.Matches(command, pattern);
                foreach (Match emailMatch in matches)
                {
                    Console.WriteLine(emailMatch.Value);
                }
            }
        }
    }
}
