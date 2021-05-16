using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Problem_4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var oddOrEven = Console.ReadLine();
            Predicate<int> predicate = oddOrEven == "even" ?
               new Predicate<int>((x) => x % 2 == 0) :
               new Predicate<int>((x) => x % 2 != 0);
            for (int i =input[0]; i <= input[1]; i++)
            {
                if (predicate(i))
                {
                    Console.Write($"{i} ");
                }
            }

        }

    }
}
