using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class AnimalFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string type, string name, double weight, string thirdParam, string fourthParam = null)
        {
            Animal animal = null;

            if (!string.IsNullOrWhiteSpace(fourthParam))
            {
                //Felines
                if (type == "Cat")
                {
                    animal = new Cat(name, weight, thirdParam, fourthParam);
                }
                else if (type == "Tiger")
                {
                    animal = new Tiger(name, weight, thirdParam, fourthParam);
                }
                
            }
            else
            {
                //Bird
                if (type == "Owl")
                {
                    animal = new Owl(name, weight, double.Parse(thirdParam));
                }
                else if (type == "Hen")
                {
                    animal = new Hen(name, weight, double.Parse(thirdParam));
                }
                //Mice and Dogs
                if (type == "Mouse")
                {
                    animal = new Mouse(name, weight, thirdParam);
                }
                else if (type == "Dog")
                {
                    animal = new Dog(name, weight, thirdParam);
                }
            }

            return animal;
        }
    }
}
