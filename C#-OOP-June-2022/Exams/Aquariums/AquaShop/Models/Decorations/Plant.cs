using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int DefualtComfort = 5;
        private const decimal DefaultPrice = 10;

        public Plant() 
            : base(DefualtComfort, DefaultPrice)
        {
        }
    }
}
