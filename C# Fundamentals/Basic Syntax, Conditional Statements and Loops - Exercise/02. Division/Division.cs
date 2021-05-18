using System;

namespace division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            
            for (int i = 2; i <= 10; i++)
            {
                
                if (number %i== 0&&i!=4&&i!=5&&i!=8)
                {
                    max = i;
                }
            }
            if (number %max == 0)
            {
                Console.WriteLine($"The number is divisible by {max}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
