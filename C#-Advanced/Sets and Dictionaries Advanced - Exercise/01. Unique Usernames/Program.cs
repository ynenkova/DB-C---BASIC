using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> name = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                name.Add(input);
            }
            Console.WriteLine(string.Join(Environment.NewLine, name));
        }
    }
}
