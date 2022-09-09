namespace AquaShop.Models.Fish
{
    internal class SaltwaterFish : Fish
    {
        private const int InitialSize = 5;
        private const int SizeIncreasementPerEating = 2;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = InitialSize;
        }

        public override void Eat()
        {
            this.Size += SizeIncreasementPerEating;
        }
    }
}
