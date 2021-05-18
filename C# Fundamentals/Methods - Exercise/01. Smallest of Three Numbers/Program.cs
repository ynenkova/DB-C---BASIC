using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int min = int.MaxValue;
            for (int i = 0; i <= 2; i++)
            {
                 int number = int.Parse(Console.ReadLine());
                if (number < min)
                {
                    min = number;
                }
            }
            Console.WriteLine(min);
        }
       
    }
}
