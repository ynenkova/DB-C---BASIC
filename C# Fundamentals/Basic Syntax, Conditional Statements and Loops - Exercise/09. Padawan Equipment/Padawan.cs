using System;

namespace _9._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double students = double.Parse(Console.ReadLine());
            double priceLight = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());
            double total = 0;
            double sumLigh = 0;
            double sumRobes = 0;
            double sumBelts = 0;
            if (students >= 6)
            {
                double freeBelt = students - Math.Floor(students / 6);
                sumBelts = priceBelts * freeBelt;
                sumRobes = priceRobes * students;
                double extraLigh = Math.Ceiling(students * 0.10);
                sumLigh = (extraLigh + students) * priceLight;
                total = sumLigh + sumBelts + sumRobes;
            }
            else
            {
                sumBelts = priceBelts * students;
                sumRobes = priceRobes * students;
                double extraLigh = Math.Ceiling(students * 0.10);
                sumLigh = (extraLigh + students) * priceLight;
                total = sumLigh + sumBelts + sumRobes;
            }
            if (total <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {total-money:f2}lv more.");
            }

        }
    }
}
