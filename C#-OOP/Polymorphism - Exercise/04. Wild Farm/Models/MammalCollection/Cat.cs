using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.MammalCollection
{
    public class Cat : Feline
    {
        private const double IncreaseCat = 0.30;
        public Cat(string name, double weight,  string livingregion, string breed) : base(name, weight,  livingregion, breed)
        {
        }

        public override void FeedAnimals(string name, int quantity)
        {

            if (name == "Vegetable" || name == "Meat")
            {
                this.FoodEaten = quantity;
                this.Weight += IncreaseCat*quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {name}!");
            }
        }

        public override string MakeSound()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
