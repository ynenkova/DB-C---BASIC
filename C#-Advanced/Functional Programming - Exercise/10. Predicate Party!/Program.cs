using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Problem_10.___Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var guest = Console.ReadLine().Split(" ").ToList();
            while (true)
            {
                var command = Console.ReadLine().Split(" ");


                if (command[0] == "Party!")
                {
                    break;
                }
                Predicate<string> predicate = ModificationGuestList(command);
                if (command[0] == "Remove")
                {
                    guest.RemoveAll(predicate);
                }
                else if (command[0] == "Double")
                {
                    for (int i = 0; i < guest.Count; i++)
                    {
                        string name = guest[i];
                        if (predicate(name))
                        {
                            guest.Insert(i + 1, name);
                            i++;
                        }
                    }
                }
            }
            Print(guest);
        }
        static void Print(List<string> guest)
        {
            if (guest.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", guest)} are going to the party!");
            }
        }
        static Predicate<string> ModificationGuestList(string[] command)
        {
            var firstArg = command[1];
            var secondArg = command[2];
            Predicate<string> pred = null;
            if (firstArg == "StartsWith")
            {
                pred = new Predicate<string>((name) =>
                  {
                      return name.StartsWith(secondArg);

                  });
            }
            else if (firstArg == "EndsWith")
            {
                pred = new Predicate<string>((name) =>
                {
                    return name.EndsWith(secondArg);

                });
            }
            else if (firstArg == "Length")
            {
                pred = new Predicate<string>((name) =>
                {
                    return name.Length == int.Parse(secondArg);

                });
            }
            return pred;
        }
    }
}
