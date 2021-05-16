using System;
using System.Linq;
using System.Collections.Generic;
namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];
            var text = Console.ReadLine().ToCharArray();
            var matrix = new char[n, m];
            int count = 0;
            int countAlf = 0;
            int start = 0;
            while (n > 0)
            {
                n--;

                for (int i = start; i < text.Length; i++)
                {
                    countAlf++;
                    if (n == 0)
                    {
                        if (m >= i + 1)
                        {
                            matrix[count, i] = text[i - start];
                        }
                    }
                    else
                    {
                        if (m >= i + 1)
                        {
                            matrix[count, i] = text[i - start];
                        }
                        else
                        {
                            start = text.Length - (countAlf - 1);
                            for (int k = 0; k < start; k++)
                            {
                                matrix[count + 1, k] = text[countAlf - 1];
                                countAlf++;
                            }
                            break;
                        }
                    }
                }
                countAlf = 0;
                count++;
            }
            count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                count++;
                int lenght = matrix.GetLength(1);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (count % 2 == 0)
                    {
                        lenght--;
                        Console.Write(matrix[row, lenght]);
                    }
                    else
                    {
                        Console.Write(matrix[row, col]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
