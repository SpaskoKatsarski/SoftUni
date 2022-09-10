using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string type, string name, double weight, string thirdParam, string fourthParam = null);
    }
}
