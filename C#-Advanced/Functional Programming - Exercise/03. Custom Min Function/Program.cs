using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Problem_3._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Func<string, int> parse = x => int.Parse(x);
            var numbers = input.Split(" ").Select(parse).Min();
            Console.WriteLine(numbers);
           
        }
    }
}
