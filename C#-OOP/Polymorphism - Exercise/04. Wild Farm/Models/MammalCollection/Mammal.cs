using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.MammalCollection
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight,string livingregion) : base(name, weight)
        {
            this.LivingRegion = livingregion;
        }
        public string LivingRegion { get;private set; }
    }
}
