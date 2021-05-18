using System;

using System.Collections.Generic;
using System.Linq;
namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<string, double>();
            var quanty = new Dictionary<string, int>();
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split(" ");
                string name = inputArgs[0];
                if (name=="buy")
                {
                    break;
                }
                double price =double.Parse(inputArgs[1]);
                int quant =int.Parse(inputArgs[2]);

                if (!result.ContainsKey(name))
                {
                    result[name] = 0;
                    quanty[name] = 0;
                }

                result[name] = price;
                quanty[name] += quant;

            }
            foreach (var item in result)
            {
                Console.Write($"{item.Key} -> ");
                foreach (var q in quanty)
                {
                    if (q.Key==item.Key)
                    {
                        double prices = q.Value * item.Value;
                        Console.Write($"{prices:f2}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
