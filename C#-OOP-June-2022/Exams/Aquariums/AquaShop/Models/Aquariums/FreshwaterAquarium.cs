using System;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int DefaultCapacity = 50;

        public FreshwaterAquarium(string name)
            : base(name, DefaultCapacity)
        {
        }
    }
}
