using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class FoodFactory : IFoodFactory
    {
        public Food CreateFood(string foodType, int foodQuantity)
        {
            Food food = null;
            if (foodType == "Vegetable")
            {
                food = new Vegetable(foodQuantity);
            }
            else if (foodType == "Fruit")
            {
                food = new Fruit(foodQuantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(foodQuantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(foodQuantity);
            }

            return food;
        }
    }
}
