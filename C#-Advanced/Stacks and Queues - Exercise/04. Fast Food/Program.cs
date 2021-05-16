using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace _4.__Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var command = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var orders = new Queue<int>(command);
            Console.WriteLine(orders.Max());
            for (int i = 0; i < command.Length; i++)
            {
                if (n >= command[i])
                {
                    orders.Dequeue();
                    n = n - command[i];
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ",orders)}");
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
