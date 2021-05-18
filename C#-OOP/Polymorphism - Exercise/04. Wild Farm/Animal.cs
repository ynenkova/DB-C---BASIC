using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract void FeedAnimals(string name, int quantity);


        public abstract string MakeSound();

        public abstract override string ToString();
        
    }
}
