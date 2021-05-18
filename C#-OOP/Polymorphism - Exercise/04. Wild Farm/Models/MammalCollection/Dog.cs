using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.MammalCollection
{
    public class Dog : Mammal
    {
        private const double IncreaseDog = 0.40;
        public Dog(string name, double weight, string livingregion) : base(name, weight,  livingregion)
        {
        }

        public override void FeedAnimals(string name, int quantity)
        {
            if (name == "Meat")
            {
                this.FoodEaten = quantity;
                this.Weight += IncreaseDog*quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {name}!");
            }
        }

        public override string MakeSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
