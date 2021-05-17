using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var type = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            while (type != "Beast!")
            {
                var input = Console.ReadLine().Split().ToArray();
                try
                {
                    if (type == "Cat")
                    {
                        var cat = new Cat(input[0], int.Parse(input[1]), input[2]);
                        animals.Add(cat);
                    }
                    else if (type == "Dog")
                    {
                        var dog = new Dog(input[0], int.Parse(input[1]), input[2]);
                        animals.Add(dog);
                    }
                    else if (type == "Frog")
                    {
                        var frog = new Frog(input[0], int.Parse(input[1]), input[2]);
                        animals.Add(frog);
                    }
                    else if (type == "Tomcat")
                    {
                        var tom = new Tomcat(input[0], int.Parse(input[1]));
                        animals.Add(tom);
                    }
                    else if (type == "Kitten")
                    {
                        var kitten = new Kitten(input[0], int.Parse(input[1]));
                        animals.Add(kitten);
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }


                type = Console.ReadLine();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
