using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Factory;
using WildFarm.MammalCollection;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string inputAnimal;
            while ((inputAnimal=Console.ReadLine()) != "End")
            {
                Animal animal = AnimalsFactory.Create(inputAnimal.Split(" "));
                animals.Add(animal);
                Console.WriteLine(animal.MakeSound());

                var inputFood = Console.ReadLine().Split(" ");
                var foods = FoodFactory.Creater(inputFood);
                try
                {
                    animal.FeedAnimals(foods.GetType().Name,foods.Quantity);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            animals.ForEach(Console.WriteLine);
        }
    }
}
