using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int first = dimensions[0];
            int second = dimensions[1];
            HashSet<int> n = new HashSet<int>();
            HashSet<int> m = new HashSet<int>();
            for (int i = 0; i < first; i++)
            {
                int number = int.Parse(Console.ReadLine());
                n.Add(number);
               
            }
            for (int i = 0; i < second ; i++)
            {
                int number = int.Parse(Console.ReadLine());
                m.Add(number);
            }
            var result = n.Intersect(m);
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
