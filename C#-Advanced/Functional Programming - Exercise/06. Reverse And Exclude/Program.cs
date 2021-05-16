using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Problem_6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var num = int.Parse(Console.ReadLine());
            Func<int, bool> filter = n => n % num!= 0;
            var reverse = input.Reverse().Where(filter);
            Console.WriteLine(string.Join(" ",reverse));
        }
    }
}
