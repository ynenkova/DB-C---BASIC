using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.MammalCollection
{
    public class Tiger : Feline
    {
        private const double IncreaseTiger = 1.00;
        public Tiger(string name, double weight, string livingregion, string breed) : base(name, weight,  livingregion, breed)
        {
        }

        public override void FeedAnimals(string name, int quantity)
        {
            if (name == "Meat")
            {
                this.FoodEaten = quantity;
                this.Weight += IncreaseTiger*quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {name}!");
            }
        }

        public override string MakeSound()
        {
           return "ROAR!!!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
