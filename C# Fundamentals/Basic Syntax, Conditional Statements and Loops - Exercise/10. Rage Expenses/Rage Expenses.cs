using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double priceHeadset = double.Parse(Console.ReadLine());
            double priceMouse = double.Parse(Console.ReadLine());
            double priceKeyboard = double.Parse(Console.ReadLine());
            double priceDisplay = double.Parse(Console.ReadLine());
            int countHead = 0;
            int countMouse = 0;
            int countKeyboard = 0;
            int countDispl = 0;
            for (int i = 1; i <= lostGames; i++)
            {
                if (i == 1)
                {
                    continue;
                }
                if (i % 2 == 0)
                {
                    countHead++;
                }
                 if (i % 3 == 0)
                {
                    countMouse++;
                }
                if (i % 2 == 0&&i%3==0)
                {
                    countKeyboard++;
                    if (countKeyboard % 2 == 0)
                    {
                        countDispl++;
                    }
                }

            }
            double sum = countHead * priceHeadset + countKeyboard * priceKeyboard + countMouse * priceMouse + countDispl * priceDisplay;
            Console.WriteLine($"Rage expenses: {sum:f2} lv.");
        }
    }
}
