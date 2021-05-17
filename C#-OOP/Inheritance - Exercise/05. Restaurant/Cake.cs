using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        
        private const double GramDess = 250;
        private const double Callori = 1000;
        private const decimal PriceCake = 5M;

        public Cake(string name) : base(name, PriceCake, GramDess, Callori)
        {
        }
    }
}
