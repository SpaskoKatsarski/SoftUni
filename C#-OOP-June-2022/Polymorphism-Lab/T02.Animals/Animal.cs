using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;

        public Animal(string name, string favFood)
        {
            this.name = name;
            this.favouriteFood = favFood;
        }

        protected string Name => this.name;

        protected string FavouriteFood => this.favouriteFood;

        public virtual string ExplainSelf()
        {
            return null;
        }
    }
}
