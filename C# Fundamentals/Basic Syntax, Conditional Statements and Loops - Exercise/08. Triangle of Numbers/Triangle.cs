using System;

namespace _8._Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int row = 1; row <= n;row++)
            {
                for (int colm= 1; colm <= row; colm++)
                {
                        Console.Write(row+" ");
                }
                Console.WriteLine();
            }

        }
    }
}
