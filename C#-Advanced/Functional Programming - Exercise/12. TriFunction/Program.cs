using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Text.Encodings;
namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(" ").ToList();
            var name = "";
            var find = Calculate(names, n, name);
            Console.WriteLine(find);
        }
         static string Calculate(List<string>names,int n, string name)
        {
                    foreach (var item in names)
                    {
                        var sum = item.ToCharArray();
                        var s = sum.Sum(x => (char)x);
                        if (s >= n)
                        {
                            name=item;
                            break;
                        }
                    }
            return name;
        }
    }
}
