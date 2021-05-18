using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            PrintChar(start, end);
        }
        static void PrintChar(char start, char end)
        {
            int startCharacter = Math.Min(start, end);
            int endCharacter = Math.Max(start, end);

            for (int i = ++startCharacter; i < endCharacter; i++)
            {
                Console.Write((char)i + " ");
            }

            Console.WriteLine();
        }
    }
}
