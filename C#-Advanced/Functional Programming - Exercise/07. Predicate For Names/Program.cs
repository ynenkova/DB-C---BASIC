using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Problem_7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var lenght = int.Parse(Console.ReadLine());
            Console.ReadLine().Split(" ").
                Where(x=>x.Length<=lenght).
                ToList().ForEach(Console.WriteLine);
        }
    }
}
