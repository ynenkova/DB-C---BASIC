using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Problem_8._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Func<int, int, int> func = new Func<int, int, int>((a, b) =>
                 {
                     if (a % 2 == 0 && b % 2 != 0)
                     {
                         return -1;
                     }
                     else if (a % 2 != 0 && b % 2 == 0)
                     {
                         return 1;
                     }
                     else
                     {
                        return a.CompareTo(b);
                     }
                 });
            Comparison<int> compar = new Comparison<int>(func);
            Array.Sort(input, compar);
            Console.WriteLine(string.Join(" ",input));
        }
    }
}
