using System;
using System.Collections.Generic;
using System.Linq;
namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new List<OrderByAge>();
            while (true)
            {
                string text = Console.ReadLine();
                if (text == "End")
                {
                    break;
                }
                string[] indentification = text.Split(" ");
                string name = indentification[0];
                string id = indentification[1];
                int age = int.Parse(indentification[2]);
                OrderByAge orders = new OrderByAge(name,id,age);
                order.Add(orders);
            }
            var orderedByAge = order.OrderBy(x => x.Age).ToList();
            foreach (var person in orderedByAge)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
    class OrderByAge
    {
        public OrderByAge(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;

        }
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}
