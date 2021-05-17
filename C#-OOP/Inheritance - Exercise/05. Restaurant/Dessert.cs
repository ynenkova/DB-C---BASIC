using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Dessert : Food
    {
        public Dessert(string name, decimal price, double grams,double calori) : base(name, price, grams)
        {
            this.Calories = calori;
        }
        public double Calories { get; set; }
    }
}
