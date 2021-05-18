using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
namespace Third
{
    class Program
    {
        static void Main(string[] args)
        {

            var allNames = new Dictionary<string, Propertis>();
            while (true)
            {
                var input = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Sail")
                {
                    break;
                }
                var names = input[0];
                var peoples =int.Parse(input[1]);
                var golds = int.Parse(input[2]);
                
                if (!allNames.ContainsKey(input[0]))
                {
                    allNames.Add(names,new Propertis(names, peoples, golds));
                    allNames[names].Name = names;
                    allNames[names].People = peoples;
                    allNames[names].Gold = golds;
                }
                else
                {
                    allNames[names].People += peoples;
                    allNames[names].Gold += golds;
                }

            }
            while (true)
            {
                var command = Console.ReadLine().Split(new[] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "End")
                {
                    break;
                }
                if (command[0] == "Plunder")
                {
                    var town = command[1];
                    var people = int.Parse(command[2]);
                    var gold = int.Parse(command[3]);
                    Console.WriteLine($"{ town} plundered! { gold} gold stolen, { people} citizens killed.");
                    allNames[town].People -= people;
                    allNames[town].Gold -= gold;
                    if (allNames[town].People == 0 || allNames[town].Gold == 0)
                    {
                        allNames.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (command[0] == "Prosper")
                {
                    var town = command[1];
                    var gold = int.Parse(command[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }
                    else
                    {
                        allNames[town].Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {allNames[town].Gold} gold.");
                    }
                }
            }

            allNames = allNames.OrderByDescending(x => x.Value.Gold).ThenBy(x => x.Value.Name).ToDictionary(x=>x.Key,x=>x.Value);

            if (allNames.Count == 0)
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");

            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {allNames.Count} wealthy settlements to go to:");
                foreach (var town in allNames)
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value.People} citizens, Gold: {town.Value.Gold} kg");
                    
                }
            }

        }
    }
    class Propertis
    {
        public Propertis(string name, int people, int gold)
        {
            this.Name = name;
            this.People = people;
            this.Gold = gold;
        }
        public string Name { get; set; }
        public int People { get; set; }
        public int Gold { get; set; }
    }
}
