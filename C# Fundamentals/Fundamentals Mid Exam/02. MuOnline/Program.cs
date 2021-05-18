using System;
using System.Linq;
using System.Collections.Generic;
namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int healt = 100;
            int bitcoints = 0;
            int room = 0;

            var commands = Console.ReadLine().Split('|').ToArray();
            for (int i = 0; i < commands.Length; i++)
            {
                string[] first = commands[i].Split().ToArray();
                room++;
                if (first[0] == "potion")
                {
                    int some = int.Parse(first[1]);

                    if (healt+some < 100)
                    {
                        healt += int.Parse(first[1]);
                        Console.WriteLine($"You healed for {first[1]} hp.");
                        Console.WriteLine($"Current health: {healt} hp.");
                    }
                    else if (healt+some>100)
                    {
                        int razlika = (healt + some) - 100;
                        int razlikaDve = some - razlika;
                        Console.WriteLine($"You healed for {razlikaDve} hp.");
                        healt = 100;
                        Console.WriteLine($"Current health: {healt} hp.");
                    }

                }
                else if (first[0] == "chest")
                {
                    bitcoints += int.Parse(first[1]);
                    Console.WriteLine($"You found {first[1]} bitcoins.");
                }
                else
                {
                    healt -= int.Parse(first[1]);
                    if (healt > 0)
                    {
                        Console.WriteLine($"You slayed {first[0]}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {first[0]}.");
                        Console.WriteLine($"Best room: {room}");
                        return;
                    }
                }
            }
            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoints}");
            Console.WriteLine($"Health: {healt}");

        }
    }
}
