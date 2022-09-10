using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        protected override IReadOnlyCollection<Type> PreferredFoods 
            => new List<Type> { typeof(Meat) }.AsReadOnly();

        protected override double WeightMultiplier 
            => TigerWeightMultiplier;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {base.Breed}, {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
