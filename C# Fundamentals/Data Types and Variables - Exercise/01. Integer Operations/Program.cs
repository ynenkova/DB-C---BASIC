using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third= int.Parse(Console.ReadLine());
            int fourd = int.Parse(Console.ReadLine());
            int total =((first + second)/third)*fourd;
            Console.WriteLine(total);
        }
    }
}
