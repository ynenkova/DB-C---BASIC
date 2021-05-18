using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int countStudent = int.Parse(Console.ReadLine());
            int countLector = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());
            double lector = 0;
            double max = 0;
            while (countStudent>0)
            {
                double studentAtendens= double.Parse(Console.ReadLine());
                countStudent--;
                double attem = studentAtendens / countLector;
                double sum =5 + bonus;
                double sumS = attem * sum;
                if (sumS>max)
                {
                    max =Math.Round(sumS);
                    lector = studentAtendens;
                }
            }
            Console.WriteLine($"Max Bonus: {max}.");
            Console.WriteLine($"The student has attended {lector} lectures.");
        }
    }
}
