using System;
using System.Linq;
using System.Collections.Generic;
namespace _9.Pokemon_Don_t_Go
{
    class Program
    {
        static void RemoveAddNumbers(List<int> numbers, int num)
        {
            for (int j = 0; j < numbers.Count; j++)
            {
                if (numbers[j] <= num)
                {
                    numbers[j] += num;
                }
                else
                {
                    numbers[j] -= num;
                }
            }
        }
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;
            while (true)
            {
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (i == n)
                    {
                        int num = numbers[i]; 
                        sum += numbers[i];
                        numbers.RemoveAt(n);
                        RemoveAddNumbers(numbers,num);
                        break;
                    }
                    if (n < 0)
                    {
                        int num = numbers[0];
                        sum += num;
                        numbers.RemoveAt(0);
                        numbers.Insert(0, numbers[numbers.Count - 1]);
                        RemoveAddNumbers(numbers, num);
                        break;
                    }
                    if (n >= numbers.Count)
                    {
                        int num = numbers[numbers.Count - 1];
                        sum += num;
                        numbers.RemoveAt(numbers.Count - 1);
                        numbers.Insert(numbers.Count, numbers[0]);
                        RemoveAddNumbers(numbers, num);
                        break;
                    }
                }
                if (numbers.Count == 0)
                {
                    break;
                }
            }
            Console.WriteLine($"{sum}");
        }
    }
}
