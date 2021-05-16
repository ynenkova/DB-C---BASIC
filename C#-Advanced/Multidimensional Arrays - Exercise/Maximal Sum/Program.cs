using System;
using System.Linq;
namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];
            var matrix = new int[n][];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            int max = 0;
            int maxRow = 0;
            int maxCol = 0;
            for (int row = 0; row < matrix.Length-2; row++)
            {
                for (int col = 0; col < matrix[row].Length-2; col++)
                {
                    int currentSum = matrix[row][ col] + matrix[row][col + 1] + matrix[row][ col + 2]+
                                     matrix[row+1][col]+ matrix[row + 1][ col+1]+ matrix[row + 1][ col+2]+
                                     matrix[row + 2][ col] + matrix[row + 2][ col + 1] + matrix[row + 2][ col + 2];
                    if (currentSum>max)
                    {
                        max = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {max}");
            for (int row = maxRow; row <= maxRow + 2; row++)
            {
                for (int col = maxCol; col <= maxCol + 2; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
