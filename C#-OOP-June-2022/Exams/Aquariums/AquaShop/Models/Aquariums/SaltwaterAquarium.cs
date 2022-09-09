using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using System;

namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int DefaultCapacity = 25;

        public SaltwaterAquarium(string name) 
            : base(name, DefaultCapacity)
        {
        }
    }
}
