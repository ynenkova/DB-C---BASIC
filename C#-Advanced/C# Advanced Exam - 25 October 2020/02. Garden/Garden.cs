
using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    public class Program
    {
        static void Main(string[] args)
        {
            var integer = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var n = integer[0];
            var m = integer[1];
            var matrix = new int[n, m];
            FillMatrix(matrix);
            var secondMarix = new List<string>();
            FlowerPosition(n, m, secondMarix);
            while (secondMarix.Count != 0)
            {
                var input = secondMarix[0].Split(" ").Select(int.Parse).ToArray();

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (row == input[0] && col == input[1])
                        {
                            for (int i = 0; i < m; i++)
                            {
                                matrix[i, col] += 1;
                                if (i != input[1] && i != input[0])
                                {
                                    matrix[row, i] += 1;
                                }
                            }
                        }
                    }

                }
                secondMarix.RemoveAt(0);
            }
            PrintMatrox(matrix);

        }

        private static void FlowerPosition(int n, int m, List<string> secondMarix)
        {
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "Bloom Bloom Plow")
                {
                    break;
                }
                var flowerPosition = command.Split(" ").Select(int.Parse).ToArray();
                if (flowerPosition[0] > n - 1 || flowerPosition[1] > m - 1)
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    secondMarix.Add(command);
                }

            }
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
        }

        private static void PrintMatrox(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
