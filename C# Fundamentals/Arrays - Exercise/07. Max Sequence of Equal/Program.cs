using System;
using System.Linq;
namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counter = 1;
            int max = 1;
            int number = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                int firstNum = numbers[i];
                int secondNum = numbers[i - 1];
                if (firstNum == secondNum)
                {
                    counter++;
                    if (max < counter)
                    {
                        max = counter;
                        number = firstNum;
                    }
                }
                else
                {
                    counter = 1;
                }
            }
            for (int i = 0; i < max; i++)
            {
                Console.Write(number +" ");
            }
            Console.WriteLine();
        }
    }
}
