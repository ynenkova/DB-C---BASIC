using System;
using System.Collections.Generic;

namespace _1._Generic_Box_of_String
{
   public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var list = new List<double>();
            for (int i = 0; i < n; i++)
            {
                var input =double.Parse( Console.ReadLine());
                list.Add(input);
            }
            var box = new Box<double>(list);

            double element= double.Parse(Console.ReadLine());
            Console.WriteLine(box.Count(element));
        }
    }
}
