using System;
using System.Linq;
using System.Collections.Generic;
namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];
            var matrix = new string[n][ ];
            for (int row = 0; row < matrix.Length; row++)
            {
               matrix[row] = Console.ReadLine().Split(' ').ToArray();
            }
            while (true)
            {
                var command = Console.ReadLine().Split(' ');
                if (command[0] == "END")
                {
                    break;
                }
                string name = command[0];
                if (name != "swap")
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int firstRow = int.Parse(command[1]);
                    int firstCol = int.Parse(command[2]);
                    int secondRow = int.Parse(command[3]);
                    int secondCol = int.Parse(command[4]);
                    if (name != "swap" || n <= firstRow ||
                        n <= secondRow || m <= firstCol ||
                        m <= secondCol || firstRow < 0 ||
                        secondRow < 0 || firstCol < 0 ||
                        secondCol < 0)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        string firts = matrix[firstRow][ firstCol];
                        matrix[firstRow][firstCol] = matrix[secondRow][ secondCol];
                        matrix[secondRow][ secondCol] = firts;
                        PritMatrix(matrix);
                    }
                }
            }
        }
        static void PritMatrix(string[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][ col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
