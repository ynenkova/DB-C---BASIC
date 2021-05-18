using System;
using System.Linq;
namespace _1.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
                sum += numbers[i];
               
            }
            for (int a = 0; a < numbers.Length; a++)
            {
               
                Console.Write(numbers[a]+" ");
            }
            Console.WriteLine();
            Console.WriteLine($"{sum}");
        }
    }
}
