using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace _5.__Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());
            var prices = new Stack<int>(clothes);
            int sum = 0;
            int rackCount = 1;
            int m = 0;
            for (int i = 0; i < clothes.Length; i++)
            {
                sum += clothes[i];
                if (sum < capacity)
                {

                    prices.Pop();
                }
                else if (sum.Equals(capacity) && prices.Any())
                {
                    rackCount++;
                    sum = 0;
                }
                else if (sum > capacity)
                {
                    rackCount++;
                    sum = clothes[i];
                }
            }
            Console.WriteLine(rackCount);
        }
    }
}
