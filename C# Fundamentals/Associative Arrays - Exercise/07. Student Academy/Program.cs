using System;
using System.Collections.Generic;
using System.Linq;
namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grades = double.Parse(Console.ReadLine());
                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                    students[name].Add(grades);
                }
                else
                {
                    students[name].Add(grades);
                    
                }

            }

            var list = students.OrderByDescending(x => x.Value.Average());
            foreach (var item in list)
            {

                if (item.Value.Average() >= 4.5)
                {
                    Console.WriteLine("{0} -> {1:f2}", item.Key, item.Value.OrderByDescending(x => x).Average());
                }
            }
        }
    }
}
