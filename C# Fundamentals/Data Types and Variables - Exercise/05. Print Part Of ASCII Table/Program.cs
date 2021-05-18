using System;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            int beginNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            for (int i = beginNum; i <= endNum; i++)
            {
                Console.Write((char)i+" ");
            }
            Console.WriteLine();
        }
    }
}
