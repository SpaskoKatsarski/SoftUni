using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int DefaultComfort = 1;
        private const decimal DefaultPrice = 5;

        public Ornament() 
            : base(DefaultComfort, DefaultPrice)
        {
        }
    }
}
