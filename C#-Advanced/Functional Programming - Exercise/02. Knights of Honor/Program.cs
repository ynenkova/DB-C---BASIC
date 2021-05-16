using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Problem_2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(" ").Select(x=>"Sir"+" "+x).ToList().ForEach(Console.WriteLine);
        }
    }
}
