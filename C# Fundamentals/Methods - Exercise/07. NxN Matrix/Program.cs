using System;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintMatrix(n);
        }
        static void PrintMatrix(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int a = 1; a <= n; a++)
                {
                    Console.Write(n+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
