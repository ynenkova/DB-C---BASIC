using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FoodShortage
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                if (input.Length==4)
                {
                    var citizen = new Citizen(input[0],int.Parse(input[1]),input[2],input[3]);
                    citizens.Add(citizen);
                }
                else
                {
                    var rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    rebels.Add(rebel);
                }
            }
            string name;
            while ((name = Console.ReadLine()) != "End")
            {
                
                if (citizens.Any(x=>x.Name==name))
                {
                    citizens.FirstOrDefault(x => x.Name == name).BuyFood();
                }
                else if (rebels.Any(x => x.Name == name))
                {
                    rebels.FirstOrDefault(x => x.Name == name).BuyFood();
                }
            }
            var total = citizens.Sum(x => x.Food);
            total += rebels.Sum(x => x.Food);
            Console.WriteLine(total);
        }
    }
}
