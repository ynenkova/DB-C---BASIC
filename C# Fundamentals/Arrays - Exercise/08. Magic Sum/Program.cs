using System;
using System.Linq;
namespace _8._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbers.Length; i++)
            {
                int firstNum = numbers[i];

                for (int j = i+1; j < numbers.Length; j++)
                {
                    int secondNum = numbers[j];
                    int sum = firstNum + secondNum;
                    if (sum == n)
                    {
                        Console.WriteLine($"{firstNum} {secondNum}");
                    }
                }
               
            }
        }
    }
}
