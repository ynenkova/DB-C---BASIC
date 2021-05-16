using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Problem_5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                if (command == "add")
                {
                    input=input.Select(y => y + 1).ToList();
                }
                if (command == "multiply")
                {
                    input = input.Select(y => y * 2).ToList();
                }
                if (command == "subtract")
                {

                    input = input.Select(y => y -1).ToList();
                }
                if (command == "print")
                {
                    Console.WriteLine(String.Join(" ", input));
                }
            }

        }
    }
}
