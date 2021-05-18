using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            int peoples = int.Parse(Console.ReadLine());
            int capacit = int.Parse(Console.ReadLine());
            int total =(int)Math.Ceiling((double) peoples / capacit);
            Console.WriteLine(total);
        }
    }
}
