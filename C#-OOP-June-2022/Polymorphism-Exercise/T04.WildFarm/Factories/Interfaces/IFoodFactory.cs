using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public interface IFoodFactory
    {
        Food CreateFood(string foodType, int foodQuantity);
    }
}
