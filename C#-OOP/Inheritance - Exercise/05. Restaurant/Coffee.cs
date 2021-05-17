using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMill = 50;
        private const decimal Coffeeprice = 3.50M;
        public Coffee(string name, double caffeine) : base(name, Coffeeprice, CoffeeMill)
        {
            this.Caffeine = caffeine;
        }
        public double Caffeine  { get; set; }
    }
}
