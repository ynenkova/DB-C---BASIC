using System;
using System.Linq;
namespace _6._Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rightSum = numbers.Sum();
            int leftSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {

                if (numbers.Length < 2)
                {
                    Console.WriteLine("0");
                    return;
                }

                rightSum -= numbers[i];
                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                leftSum += numbers[i];
                // 10 5 5 99 3 4 2 5 1 1 4

            }
            Console.WriteLine("no");
        }
    }
}
