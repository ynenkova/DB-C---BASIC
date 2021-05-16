using System;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] numbers = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    numbers[row, col] = currentRow[col];
                }

            }
            int sumFirst = 0;
            int sumSecond = 0;
            for (int row = 0; row < numbers.GetLength(0); row++)
            {
                for (int col = row; col < numbers.GetLength(1); col++)
                {
                    n--;
                    if (row == 0)
                    {
                        sumFirst += numbers[row, col];
                        sumSecond += numbers[row, n];
                    }
                    else
                    {
                        sumFirst += numbers[row , col ];
                        sumSecond += numbers[row, n];
                    }
                    break;
                }
            }
            Console.WriteLine($"{Math.Abs(sumFirst-sumSecond)}");
        }
    }
}
