using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name,Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) ||  value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public Dough Dough {private get => dough; set => dough = value; }

        public int CountTopping()
        {
            return this.toppings.Count;
        }
        public void Add(Topping topping)
        {
            if (this.toppings.Count==10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }
        public double Callories()
        {
            var total = this.Dough.CalculateCalories();
            foreach (var topping in this.toppings)
            {
                total += topping.CalculateToppingCalor();
            }
            return total;
        }
        

    }
}

