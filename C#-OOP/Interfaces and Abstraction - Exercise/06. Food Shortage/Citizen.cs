using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IInformation, IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthday;
        private int food;

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthday;
            this.Food = 0;
           
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string BirthDate { get; private set; }
        public int Food { get; private set; }


        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
