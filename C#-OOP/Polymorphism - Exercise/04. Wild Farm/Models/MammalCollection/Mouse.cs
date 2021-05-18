using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.MammalCollection
{
    public class Mouse : Mammal
    {
        private const double IncreaseMouse = 0.10;
        public Mouse(string name, double weight,  string livingregion) : base(name, weight,  livingregion)
        {
        }

        public override void FeedAnimals(string name, int quantity)
        {
            if (name== "Vegetable"||name=="Fruit")
            {
                this.FoodEaten = quantity;
                this.Weight += IncreaseMouse*quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {name}!");
            }
        }

        public override string MakeSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
