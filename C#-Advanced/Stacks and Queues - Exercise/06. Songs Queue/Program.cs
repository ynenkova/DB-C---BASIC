using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace _6.__Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries ).ToArray();
            var playlist = new Queue<string>(songs);
            while (true)
            {
                var command = Console.ReadLine().Split(" ");


                string song = string.Join(" ", command.Skip(1));
                if (!playlist.Any())
                {
                    Console.WriteLine("No more songs!");
                    return;
                }
                if (command[0] == "Play" && playlist.Any())
                {
                    playlist.Dequeue();
                }
                else if (command[0] == "Add")
                {
                    
                    if (!playlist.Contains(song))
                    {
                        playlist.Enqueue(song);

                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", playlist));
                }

            }
            
        }
    }
}
