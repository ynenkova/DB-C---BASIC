using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int chars1 = 97 + i;
                for (int k = 0; k < n; k++)
                {
                    int chars2 = 97 + k;
                    for (int b = 0; b < n; b++)
                    {
                        int chars = 97 + b;
                        Console.WriteLine($"{(char)chars1}{(char)chars2}{(char)chars}");
                    }
                }
            }

        }
    }
}
