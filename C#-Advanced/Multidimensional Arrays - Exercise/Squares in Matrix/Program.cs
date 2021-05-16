using System;
using System.Linq;
namespace _2._2X2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];
            var matrix = new string[n, m];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow =Console.ReadLine().Split(' ').ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col]= currentRow[col];
                }
            }
            int count = 0;
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    if (matrix[row,col]== matrix[row, col+1]&& matrix[row+1, col]== matrix[row+1, col+1]&& matrix[row, col] == matrix[row + 1, col])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
