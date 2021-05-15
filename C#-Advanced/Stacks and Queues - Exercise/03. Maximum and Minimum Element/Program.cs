using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace _3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();
                if (command[0]=="1")
                {
                    int s = int.Parse(command[1]);
                    numbers.Push(s);
                }
               else if (command[0] == "2" && numbers.Any())
                {
                    numbers.Pop();
                }
               else if (command[0] == "3"&&numbers.Any())
                {
                    Console.WriteLine(numbers.Max());
                }
                else if (command[0] == "4" && numbers.Any())
                {
                    Console.WriteLine(numbers.Min());
                }
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
