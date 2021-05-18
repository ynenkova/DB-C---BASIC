using System;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePowerNperStart = int.Parse(Console.ReadLine());
            int pokePowerNcurrent = pokePowerNperStart;
            int distanceM = int.Parse(Console.ReadLine());
            int exhaustionFactorY = int.Parse(Console.ReadLine());
            int targetsPokedCount = 0;

            while (pokePowerNcurrent >= distanceM)
            {
                if (pokePowerNcurrent == pokePowerNperStart / 2)
                {
                    if (exhaustionFactorY > 0)
                    {
                        pokePowerNcurrent /= exhaustionFactorY;
                    }

                }
                if (pokePowerNcurrent - distanceM < 0)
                {
                    break;
                }
                else
                {
                    pokePowerNcurrent -= distanceM;
                    targetsPokedCount++;
                }
            }
            Console.WriteLine(pokePowerNcurrent);
            Console.WriteLine(targetsPokedCount);
        }
    }
}
