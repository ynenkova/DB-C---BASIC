using System;
using System.Linq;
using System.Collections.Generic;
namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(new[] {',',' '},StringSplitOptions.RemoveEmptyEntries).ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="Craft!")
                {
                    break;
                }
                var command = input.Split(new[] { '-',':',' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0]== "Collect")
                {
                    if (!list.Contains(command[1]))
                    {
                        list.Add(command[1]);
                    }
                }
               else if (command[0] == "Drop")
                {
                    if (list.Contains(command[1]))
                    {
                        string index = command[1];
                        list.Remove(index);
                    }
                }
               else if (command[0] == "Combine")
                {
                    string old = command[2];
                    string newItem = command[3];
                    int index = 0;
                    if (list.Contains(old))
                    {
                        
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i]==old)
                            {
                                index = i+1;
                                break;
                            }
                        }
                        list.Insert(index, newItem);
                    }
                }
              else  if (command[0] == "Renew")
                {
                    if (list.Contains(command[1]))
                    {
                        string name = command[1];
                        int index = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i]==name)
                            {
                                list.RemoveAt(i);
                                list.Add(name);
                            }
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(", ",list));
        }
    }
}
