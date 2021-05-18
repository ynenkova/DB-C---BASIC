using System;
using System.Numerics;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger num = 0;
            double snow = 0;
            double time = 0;
            double quality = 0;
            for (int i = 1; i <= n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
             BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                if (num < snowballValue)
                {
                    num = snowballValue;
                    snow = snowballSnow;
                    time = snowballTime;
                    quality = snowballQuality;
                }
            }
            Console.WriteLine($"{snow} : {time} = {num} ({quality})");
        }
    }
}
