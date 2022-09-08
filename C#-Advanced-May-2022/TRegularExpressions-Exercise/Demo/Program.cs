using System;
using System.Text.RegularExpressions;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(?<name>[A-Za-z])?(?<distance>\d)?");
        }
    }
}
