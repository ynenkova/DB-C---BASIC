using System;
using System.Collections.Generic;
using System.Linq;
namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = new Dictionary<string, int>();
            var language = new Dictionary<string, int>();
            while (true)
            {
                string[] command = Console.ReadLine().Split("-").ToArray();
                if (command[0] == "exam finished")
                {
                    break;
                }
                string name = command[0];
                string lang = command[1];
                if (command.Length < 3)
                {
                    if (line.ContainsKey(command[0]))
                    {
                        line.Remove(command[0]);
                    }
                }
                else
                {
                    if (language.ContainsKey(lang))
                    {

                        language[lang]++;
                    }
                    else
                    {
                        language.Add(lang, 1);
                    }
                    if (!line.ContainsKey(name))
                    {
                        int points = int.Parse(command[2]);
                        line.Add(name, points);
                    }
                    else
                    {
                        int points = int.Parse(command[2]);
                        if (points > line[name])
                        {
                            line[name] = points;
                        }
                    }
                }

            }
            Console.WriteLine($"Results:");
            foreach (var user in line.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }
            Console.WriteLine($"Submissions:");
            foreach (var item in language.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
