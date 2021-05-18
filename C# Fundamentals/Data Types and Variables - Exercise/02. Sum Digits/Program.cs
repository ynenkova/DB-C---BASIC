using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                char number = num[i];
                int currentNum = int.Parse(number.ToString());
                sum += currentNum;
            }
            Console.WriteLine(sum);
        }
    }
}
