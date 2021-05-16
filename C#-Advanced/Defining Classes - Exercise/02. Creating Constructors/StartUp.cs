using Creating_Constructors;
using System;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Person pesho = new Person(name, age);
            
            Console.WriteLine($"{pesho.Name} -> {pesho.Age}");
        }
    }
}
