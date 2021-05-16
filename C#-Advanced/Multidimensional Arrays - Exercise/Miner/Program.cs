using System;
using System.Linq;
using System.Collections.Generic;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine().Split(' ').ToArray();
            var array = new string[n, n];
            var allCoals = 0;
            int currentRow = 0;
            int currentCol = 0;
            int cuurrentCoals = 0;

            for (int row = 0; row < array.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < array.GetLength(1); col++)
                {
                    array[row, col] = input[col];
                    if (input[col] == "s")
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    if (input[col] == "c")
                    {
                        allCoals++;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                
                if (commands[i] == "left")
                {
                    if (currentCol - 1 < 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (array[currentRow, currentCol - 1] == "e")
                        {
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol - 1})");
                            return;
                        }
                        else if (array[currentRow, currentCol - 1] == "c")
                        {
                            cuurrentCoals++;
                            array[currentRow, currentCol - 1] = "*";
                            currentCol = currentCol - 1;
                        }
                        else
                        {
                            currentCol = currentCol - 1;
                        }
                    }
                }
                else if (commands[i] == "right")
                {
                    if (currentCol + 1 >= n)
                    {
                        continue;
                    }
                    else
                    {
                        if (array[currentRow, currentCol + 1] == "e")
                        {
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol + 1})");
                            return;
                        }
                        else if (array[currentRow, currentCol + 1] == "c")
                        {
                            cuurrentCoals++;
                            array[currentRow, currentCol + 1] = "*";
                            currentCol = currentCol + 1;
                        }
                        else
                        {
                            currentCol = currentCol + 1;
                        }
                    }
                }
                else if (commands[i] == "up")
                {
                    if (currentRow + 1 < 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (array[currentRow - 1, currentCol] == "e")
                        {
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol + 1})");
                            return;
                        }
                        else if (array[currentRow - 1, currentCol] == "c")
                        {
                            cuurrentCoals++;
                            array[currentRow - 1, currentCol] = "*";
                            currentRow = currentRow - 1;
                        }
                        else
                        {
                            currentRow = currentRow - 1;
                        }
                    }
                }
                else if (commands[i] == "down")
                {
                    if (currentRow + 1 >= n)
                    {
                        continue;
                    }
                    else
                    {
                        if (array[currentRow + 1, currentCol] == "e")
                        {
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol + 1})");
                            return;
                        }
                        else if (array[currentRow + 1, currentCol] == "c")
                        {
                            cuurrentCoals++;
                            array[currentRow + 1, currentCol] = "*";
                            currentRow = currentRow + 1;
                        }
                        else
                        {
                            currentRow = currentRow + 1;
                        }
                    }
                }
                if (allCoals == cuurrentCoals)
                {
                    Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                    return;
                }
            }
            Console.WriteLine($"{allCoals - cuurrentCoals} coals left. ({currentRow}, {currentCol})");
        }
    }
}
