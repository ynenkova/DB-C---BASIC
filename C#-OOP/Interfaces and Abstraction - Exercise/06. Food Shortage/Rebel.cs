using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IInformation, IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food;

        public Rebel(string name, int age,string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }

        public int Food { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }
        public string Group { get => group; set => group = value; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
