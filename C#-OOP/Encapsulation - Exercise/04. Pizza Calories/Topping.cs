using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
   public class Topping
    {
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;
        private const double Calor = 2;

        private string toppingtype;
        private int weight;

        public Topping(string toppingtype, int weight)
        {
            this.Toppingtype = toppingtype;
            this.Weight = weight;
        }

        public string Toppingtype
        {
            get
            {
                return this.toppingtype;
            }
            set
            {
                if (value.ToLower()!= "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.toppingtype = value;
            }
        }
        public int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value<1||value>50)
                {
                    throw new ArgumentException($"{this.toppingtype} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }
        public double CalculateToppingCalor()
        {
            var result = this.Weight * Calor;
            switch (this.Toppingtype.ToLower())
            {
                case "meat":
                    result *= Meat;
                    break;
                case "veggies":
                    result *= Veggies;
                    break;
                case "cheese":
                    result *= Cheese;
                    break;
                case "sauce":
                    result *= Sauce;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
