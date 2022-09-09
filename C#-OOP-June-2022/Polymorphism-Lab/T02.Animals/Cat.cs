using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favFood) 
            : base(name, favFood)
        {

        }

        public override string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"I am {base.Name} and my fovourite food is {base.FavouriteFood}");
            sb.AppendLine("MEEOW");
            return sb.ToString().TrimEnd();
        }
    }
}
