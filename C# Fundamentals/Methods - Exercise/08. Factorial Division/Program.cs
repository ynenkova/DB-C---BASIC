using System;

namespace _8._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = int.Parse(Console.ReadLine());
            long m = int.Parse(Console.ReadLine());
            double rezult = factorial(n) / factorial(m);

            Console.WriteLine($"{rezult:f2}");
        }
        static double factorial(double h)
        {
            if (h == 0)
            {
                return 1;
            }
            else
            {
                return (h * factorial(h - 1));
            }
        }
    }
}
