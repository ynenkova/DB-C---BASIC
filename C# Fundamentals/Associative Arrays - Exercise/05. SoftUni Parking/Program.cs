using System;
using System.Collections.Generic;
using System.Linq;
namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var users = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0]=="register")
                {
                    if (!users.ContainsKey(command[1]))
                    {
                        users.Add(command[1],command[2]);
                        Console.WriteLine($"{command[1]} registered {command[2]} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {command[2]}");
                    }
                }
                if (command[0] == "unregister")
                {
                    if (!users.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"ERROR: user {command[1]} not found");
                    }
                    else
                    {
                        string name = command[1];
                        users.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }
            }
            foreach (var item in users)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
