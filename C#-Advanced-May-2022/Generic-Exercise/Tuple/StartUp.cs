using System;

namespace Tuple
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] nameAndAdress = Console.ReadLine()
                .Split();

            string fullName = $"{nameAndAdress[0]} {nameAndAdress[1]}";
            string adress = nameAndAdress[2];

            Console.WriteLine(new Tuple<string, string>(fullName, adress));

            string[] nameAndAmountOfBeer = Console.ReadLine()
                .Split();

            string nameOfDrinker = nameAndAmountOfBeer[0];
            int amountOfBeer = int.Parse(nameAndAmountOfBeer[1]);

            //Tuple<string, int> drinkerInfo = new Tuple<string, int>(nameOfDrinker, amountOfBeer);
            //Console.WriteLine(drinkerInfo);
            Console.WriteLine(new Tuple<string, int>(nameOfDrinker, amountOfBeer));

            string[] numbers = Console.ReadLine()
                .Split();

            int intValue = int.Parse(numbers[0]);
            double doubleValue = double.Parse(numbers[1]);

            Console.WriteLine(new Tuple<int, double>(intValue, doubleValue));
        }
    }
}
