using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        private const double DogWeightMultiplier = 0.40;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {

        }

        protected override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type> { typeof(Meat) }.AsReadOnly();

        protected override double WeightMultiplier
            => DogWeightMultiplier;

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
