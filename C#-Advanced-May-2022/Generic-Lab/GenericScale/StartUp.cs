using System;

namespace GenericScale
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> numbers = new EqualityScale<int>(5, 5);
            Console.WriteLine(numbers.AreEqual());

            EqualityScale<int> numbers2 = new EqualityScale<int>(1, 5);
            Console.WriteLine(numbers2.AreEqual());

            //EqualityScale<Cat> cats = new EqualityScale<Cat>(new Cat("Gosho", 5), new Cat("Gosho", 6));
            //Console.WriteLine(cats.AreEqual());

            //EqualityScale<Cat> cats2 = new EqualityScale<Cat>(new Cat("Gosho", 5), new Cat("Gosho", 5));
            //Console.WriteLine(cats2.AreEqual());
        }
    }
}
