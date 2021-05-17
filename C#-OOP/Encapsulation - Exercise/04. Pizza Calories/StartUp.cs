using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split(" ");
            var doughSplit = Console.ReadLine().Split(" ");
            try
            {
                Dough dough = new Dough(doughSplit[1], doughSplit[2], int.Parse(doughSplit[3]));
                Pizza pizza = new Pizza(command[1], dough);
                var topping = Console.ReadLine();
                while (topping != "END")
                {
                    var split = topping.Split(" ");
                    try
                    {
                        var top = new Topping(split[1], int.Parse(split[2]));
                        pizza.Add(top);
                    }
                    catch (Exception m)
                    {
                        Console.WriteLine(m.Message);
                        return;
                    }
                    topping = Console.ReadLine();
                }
                Console.WriteLine($"{pizza.Name} - {pizza.Callories():f2} Calories.");
            }
            catch (Exception v)
            {
                Console.WriteLine(v.Message);
            }

            
        }
    }
}
