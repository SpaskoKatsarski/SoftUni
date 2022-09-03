using System;
using System.Text;

namespace Threeuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //{first name} {last name} {address} {town} - input
            //Adam Smith -> Wallstreet -> New York - output
            string[] personInfo = Console.ReadLine()
                .Split();

            string fullName = $"{personInfo[0]} {personInfo[1]}";
            string adress = personInfo[2];
            StringBuilder sb = new StringBuilder();
            for (int i = 3; i < personInfo.Length; i++)
            {
                sb.Append(personInfo[i]);
                sb.Append(' ');
            }
            string city = sb.ToString();

            Threeuple<string, string, string> threeupleOne = new Threeuple<string, string, string>(fullName, adress, city);
            //tupleOne.FirstElement = "Jerry Smith"; -> because of the setter
            Console.WriteLine(threeupleOne);


            //{name} {liters of beer} {drunk or not} - input
            //Mark -> 18 -> True - output
            string[] beerInfo = Console.ReadLine()
                .Split();

            string drinker = beerInfo[0];
            int litersOfBeer = int.Parse(beerInfo[1]);
            bool isDrunk = beerInfo[2] == "drunk";

            Threeuple<string, int, bool> threeupleTwo = new Threeuple<string, int, bool>(drinker, litersOfBeer, isDrunk);
            Console.WriteLine(threeupleTwo);

            //{name} {account balance} {bank name} - input
            //Karren -> 0.1 -> USBank - output
            string[] bankInfo = Console.ReadLine()
                .Split();

            string name = bankInfo[0];
            double accountBalance = double.Parse(bankInfo[1]);
            string bankName = bankInfo[2];

            Threeuple<string, double, string> threeupleThree = new Threeuple<string, double, string>(name, accountBalance, bankName);
            Console.WriteLine(threeupleThree);
        }
    }
}
