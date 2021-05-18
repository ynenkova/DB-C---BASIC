using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.FoodCollection;

namespace WildFarm
{
    public class Hen : Bird
    {
        private const double IncreaseHen = 0.35;
        public Hen(string name, double weight,  double wing) : base(name, weight, wing)
        {
        }

        public override void FeedAnimals(string name, int quantity)
        {
            this.FoodEaten = quantity;
            this.Weight += IncreaseHen*quantity;
        }

        public override string MakeSound()
        {
           return "Cluck";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
