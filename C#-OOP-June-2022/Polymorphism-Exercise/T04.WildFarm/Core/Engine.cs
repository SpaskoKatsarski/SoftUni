using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;

        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        private Engine()
        {
            this.animals = new List<Animal>();
        }

        public Engine(IAnimalFactory animalFactory, IFoodFactory foodFactory)
            : this()
        {
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
        }

        public void Start()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] animalArgs = command
                        .Split();
                    string[] foodArgs = Console.ReadLine()
                        .Split();

                    //string type, string name, double weight, string thirdParam, string fourthParam = null
                    string type = animalArgs[0];
                    string name = animalArgs[1];
                    double weight = double.Parse(animalArgs[2]);
                    string thirdParam = animalArgs[3];

                    Animal animal = null;
                    if (animalArgs.Length == 5)
                    {
                        //Felines
                        animal = this.animalFactory.CreateAnimal(type, name, weight, thirdParam, animalArgs[4]);
                    }
                    else if (animalArgs.Length == 4)
                    {
                        //Hens or Dogs or Mice
                        animal = this.animalFactory.CreateAnimal(type, name, weight, thirdParam);
                    }

                    Food food = this.foodFactory.CreateFood(foodArgs[0], int.Parse(foodArgs[1]));

                    Console.WriteLine(animal.ProduceSound());
                    this.animals.Add(animal);
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
