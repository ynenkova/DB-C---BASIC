using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        private const double IncreaseOwn = 0.25;
        public Owl(string name, double weight, double wing) : base(name, weight, wing)
        {
        }

        public override void FeedAnimals(string name, int quantity)
        {
            if (name=="Meat")
            {
                this.FoodEaten = quantity;
                this.Weight += IncreaseOwn*quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {name}!");
            }
        }

        public override string MakeSound()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
