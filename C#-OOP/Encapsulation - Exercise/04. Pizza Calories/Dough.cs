using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
   public class Dough
    {
        private const double White = 1.5;
        private const double Wholegrain  = 1.0;
        private const double Crispy  = 0.9;
        private const double Chewy  = 1.1;
        private const double Homemade  = 1.0;
        private const int Calories = 2;

        private string flourtype;
        private string bakeingtehnig;
        private int weight;

        public Dough(string flourtype, string bakeingtehnig,int weight)
        {
            this.Flourtype = flourtype;
            this.Bakeingtehnig = bakeingtehnig;
            this.Weight = weight;
        }

        public string Flourtype
        {
            get
            {
                return this.flourtype;
            }
           private set
            {
                if (value.ToLower()!= "white" && value.ToLower()!= "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourtype = value;
            }
        }
        public string Bakeingtehnig
        {
            get
            {
                return this.bakeingtehnig;
            }
           private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakeingtehnig = value;
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double result = Calories*this.Weight;
            switch (this.Flourtype.ToLower())
            {
                case "white":
                    result *= White;
                    break;
                case "wholegrain":
                    result *= Wholegrain;
                    break;
                default:
                    break;
            }

            switch (this.Bakeingtehnig.ToLower())
            {
                case "crispy":
                    result *= Crispy;
                    break;
                case "chewy":
                    result *= Chewy;
                    break;
                case "homemade":
                    result *= Homemade;
                    break;
                default:
                    break;
            }
            
            return result;
        }
    }
}
