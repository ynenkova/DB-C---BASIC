using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
   abstract class FactoryHero
    {
        public static BaseHero GetBaseHero(string type,string name)
        {
            BaseHero baseHero = null;
            if (type=="Druid")
            {
                baseHero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                baseHero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                baseHero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                baseHero = new Warrior(name);
            }
            return baseHero;
        }
    }
}
