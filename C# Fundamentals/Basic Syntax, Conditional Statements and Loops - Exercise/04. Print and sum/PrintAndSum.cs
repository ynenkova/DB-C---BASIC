using System;

namespace print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int inNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = inNum; i <= endNum; i++)
            {
                sum += i;
                Console.Write(i+" ");

            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
