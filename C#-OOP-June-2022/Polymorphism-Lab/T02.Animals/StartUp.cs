using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            animals.Add(new Cat("Peter", "Whiskas"));
            animals.Add(new Dog("George", "Meat"));
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ExplainSelf());
                if (animal is Cat cat && cat.ExplainSelf() == "I am Peter and my fovourite food is Whiskas\r\nMEEOW")
                {
                    Console.WriteLine("WE FOUND IT");
                }
                else if (animal is Dog)
                {
                    Console.WriteLine("Don't use this method to find the right class!");
                }
            }
        }
    }
}
