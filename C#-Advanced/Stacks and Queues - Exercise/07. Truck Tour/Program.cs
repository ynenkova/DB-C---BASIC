using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace _7.__Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var pumps = new Queue<int[]>();
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                var petrolKm = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(petrolKm);

            }
            while (true)
            {
                int sum = 0;
                bool found = true;
                for (int i = 0; i < n; i++)
                {
                    int[] current = pumps.Dequeue();

                    sum += current[0];
                    if (sum < current[1])
                    {
                        found = false;
                    }
                    sum -= current[1];
                    pumps.Enqueue(current);
                }
                if (found)
                {
                    break;
                }
                count++;
                pumps.Enqueue(pumps.Dequeue());
            }
            Console.WriteLine(count);
        }
    }
}
