using System;
using System.Linq;
using System.Collections.Generic;
namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var jagged = new int[n][];
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[i] = input;

            }
            for (int i = 0; i < n; i++)
            {
                if (i == n - 1)
                {
                    break;
                }
                if (jagged[i].GetLength(0) == jagged[i + 1].GetLength(0))
                {
                    jagged[i] = jagged[i].Select(x => x * 2).ToArray();
                    jagged[i + 1] = jagged[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jagged[i] = jagged[i].Select(x => x / 2).ToArray();
                    jagged[i + 1] = jagged[i + 1].Select(x => x / 2).ToArray();
                }
            }
            while (true)
            {
                var text = Console.ReadLine();
                if (text == "End")
                {
                    break;
                }
                var command = text.Split(" ").ToArray();
                string first = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if (first == "Add")
                {
                    if (row >= n || row < 0 || col < 0 || col >= jagged[row].Length)
                    {
                        continue;
                    }
                    else
                    {
                        jagged[row][col] += value;
                    }
                }
                else if (first == "Subtract")
                {
                    if (row >= n || row < 0 || col < 0 || col >= jagged[row].Length)
                    {
                        continue;
                    }
                    else
                    {
                        jagged[row][col] -= value;
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine,jagged.Select(x=>string.Join(" ",x))));
        }
    }
}
