using CatDatabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatDatabase
{
    public class Cat : ICat
    {
        public Cat(string name, string description, int age)
        {
            this.Name = name;
            this.Description = description;
            this.Age = age;
        }

        public string Name { get; private set; }
        
        public string Description { get; private set; }

        public int Age { get; private set; }

        public void Meow()
        {
            Console.WriteLine("Meow");
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Description: {this.Description}, Age: {this.Age}";
        }
    }
}
