using System;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IFoodFactory ff = new FoodFactory();
            IAnimalFactory af = new AnimalFactory();

            IEngine engine = new Engine(af, ff);
            engine.Start();
        }
    }
}
