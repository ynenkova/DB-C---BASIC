using System;
using System.Linq;
using System.Collections.Generic;
namespace _10.Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] lair = new char[matrixSize[0], matrixSize[1]];
            int[] playerStartCoord = new int[2];
            for (int i = 0; i < matrixSize[0]; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < matrixSize[1]; j++)
                {
                    if (row[j] == 'P')
                    {
                        playerStartCoord[0] = i;
                        playerStartCoord[1] = j;
                        lair[i, j] = '.';
                    }
                    else lair[i, j] = row[j];
                }
            }
            string commands = Console.ReadLine();
            int currentXpos = playerStartCoord[1];
            int currentYpos = playerStartCoord[0];
            bool dead = false;
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'U':
                        currentYpos--;
                        break;
                    case 'D':
                        currentYpos++;
                        break;
                    case 'L':
                        currentXpos--;
                        break;
                    case 'R':
                        currentXpos++;
                        break;
                }
                if (CheckForEscaping(currentXpos, currentYpos, lair))
                {
                    if (currentXpos < 0) currentXpos = 0;
                    if (currentXpos == lair.GetLength(1)) currentXpos--;
                    if (currentYpos < 0) currentYpos = 0;
                    if (currentYpos == lair.GetLength(0)) currentYpos--;
                    BunniesSpread(lair);
                    break;
                }
                BunniesSpread(lair);
                if (CheckForBunniesReachPlayer(currentXpos, currentYpos, lair))
                {
                    dead = true;
                    break;
                }
            }
            PrintMatrix(lair);
            if (dead) Console.WriteLine($"dead: {currentYpos} {currentXpos}");
            else Console.WriteLine($"won: {currentYpos} {currentXpos}");
        }

        static bool CheckForEscaping(int Xpos, int Ypos, char[,] matrix)
        {
            if (Xpos < 0 || Xpos >= matrix.GetLength(1) || Ypos < 0 || Ypos >= matrix.GetLength(0)) return true;
            return false;
        }

        static void BunniesSpread(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        if (!CheckForEscaping(j - 1, i, matrix) && matrix[i, j - 1] == '.') matrix[i, j - 1] = 'N';
                        if (!CheckForEscaping(j + 1, i, matrix) && matrix[i, j + 1] == '.') matrix[i, j + 1] = 'N';
                        if (!CheckForEscaping(j, i + 1, matrix) && matrix[i + 1, j] == '.') matrix[i + 1, j] = 'N';
                        if (!CheckForEscaping(j, i - 1, matrix) && matrix[i - 1, j] == '.') matrix[i - 1, j] = 'N';
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'N') matrix[i, j] = 'B';
                }
            }
        }

        static bool CheckForBunniesReachPlayer(int Xpos, int Ypos, char[,] matrix)
        {
            if (matrix[Ypos, Xpos] == 'B') return true;
            else return false;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}



