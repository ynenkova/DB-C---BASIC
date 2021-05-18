using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
   public class StratUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            List<BaseHero> baseHero = new List<BaseHero>();
            var count = 0;
            while (count!=n)
            {
                var heroName = Console.ReadLine();
                var heroType = Console.ReadLine();
                BaseHero factory = FactoryHero.GetBaseHero(heroType, heroName);
                if (factory!=null)
                {
                    baseHero.Add(factory);
                    count++;
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }
            var bossPower = int.Parse(Console.ReadLine());
            foreach (var hero in baseHero)
            {
                Console.WriteLine(hero.CastAbility());
            }
            var totalPower = baseHero.Sum(x => x.Power);
            if (totalPower>=bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
