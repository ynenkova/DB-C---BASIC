using System;
using System.Linq;
using System.Collections.Generic;
namespace _8
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var array = new int[n, n];
            for (int row = 0; row < array.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    array[row, col] = input[col];
                }
            }
            var bombPlace = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int i = 0; i < bombPlace.Length; i++)
            {
                var bomb = bombPlace[i].Split(',').ToArray();
                int row = int.Parse(bomb[0]);
                int col = int.Parse(bomb[1]);
                int value = array[row, col];
                if (IsToExplode(row - 1, col - 1,array,n)) array[row - 1,col - 1] -= value;
                if (IsToExplode(row - 1, col + 1, array, n)) array[row - 1,col + 1] -= value;
                if (IsToExplode(row, col - 1, array, n)) array[row,col - 1] -= value;
                if (IsToExplode(row, col + 1, array, n)) array[row,col + 1] -= value;
                if (IsToExplode(row + 1, col - 1, array, n)) array[row + 1,col - 1]-=value;
                if (IsToExplode(row + 1, col + 1, array, n)) array[row + 1,col + 1] -= value;
                if (IsToExplode(row - 1, col, array, n)) array[row - 1,col] -= value;
                if (IsToExplode(row + 1, col, array, n)) array[row + 1,col] -= value;

                array[row,col] = 0;

            }
            int count = 0;
            int sum = 0;
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    if (array[row, col] > 0)
                    {
                        count++;
                        sum += array[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write($"{array[row, col]} ");
                }
                Console.WriteLine();
            }
        }
        private static bool IsToExplode(int row, int col,int[,]array,int n)
        {
            return row >= 0 && row < array.Length && col >= 0 && col < n-1 &&array[row,col] > 0;
        }
    }
}
