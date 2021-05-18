using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                char inchar = char.Parse(Console.ReadLine());
                sum += inchar;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
