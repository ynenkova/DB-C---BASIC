using System;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersFirst = int.Parse(Console.ReadLine());
            int numbersSecond = int.Parse(Console.ReadLine());
            int numbersThirt = int.Parse(Console.ReadLine());
            int result = PrintNumberSum(numbersFirst, numbersSecond, numbersThirt);
            Console.WriteLine(result);
        }
        static int PrintNumberSum(int numberFirst,int numbersSecond, int numbersThirt)
        {
            return (numberFirst + numbersSecond) - numbersThirt;
        }
    }
}
