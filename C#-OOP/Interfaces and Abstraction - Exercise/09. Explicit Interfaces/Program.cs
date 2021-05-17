using System;

namespace ExplicitInterfaces
{
   public class Program
    {
        static void Main(string[] args)
        {
            Citizen citizen;
            string input;
            while ((input=Console.ReadLine())!="End")
            {
                var line = input.Split(" ");
                citizen = new Citizen(line[0], line[1], int.Parse(line[2]));
                Console.WriteLine(citizen.GetName(citizen.Name));
                Console.Write(citizen.GetName(), citizen.GetName(citizen.Name));
                Console.Write(citizen.GetName(citizen.Name));
                Console.WriteLine();
            }
        }
    }
}
