using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight,double wing) : base(name, weight)
        {
            this.WingSize = wing;
        }
        public double WingSize { get;private set; }
    }
}
