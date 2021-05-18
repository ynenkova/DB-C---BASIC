using System;

namespace _7.Vending_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double sum = 0;

            while (name != "Start")
            {
                double coints = double.Parse(name);

                if (coints != 0.1 && coints != 0.2 && coints != 0.5 && coints != 1 && coints != 2)
                {
                    Console.WriteLine($"Cannot accept {coints}");
                }
                else
                {
                    sum += coints;
                }
                name = Console.ReadLine();
            }
            while (name != "End")
            {
                name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }
                if (name == "Nuts")
                {
                    if (sum < 2.0)
                    {
                        Console.WriteLine("Sorry, not enough money.");
                    }
                    else
                    {
                        sum -= 2.0;
                        Console.WriteLine("Purchased nuts");
                    }
                }
                else if (name == "Water")
                {
                    if (sum < 0.7)
                    {
                        Console.WriteLine("Sorry, not enough money.");
                    }
                    else
                    {
                        sum -= 0.7;
                        Console.WriteLine("Purchased water");
                    }
                }
                else if (name == "Crisps")
                {
                    if (sum < 1.5)
                    {
                        Console.WriteLine("Sorry, not enough money.");
                    }
                    else
                    {
                        sum -= 1.5;
                        Console.WriteLine("Purchased crisps");
                    }
                }
                else if (name == "Soda")
                {
                    if (sum < 0.8)
                    {
                        Console.WriteLine("Sorry, not enough money.");
                    }
                    else
                    {
                        sum -= 0.8;
                        Console.WriteLine("Purchased soda");
                    }
                }
                else if (name == "Coke")
                {
                    if (sum < 1.0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        sum -= 1.0;
                        Console.WriteLine("Purchased coke");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }
            Console.WriteLine($"Change: {sum:f2}");
        }
    }
}
