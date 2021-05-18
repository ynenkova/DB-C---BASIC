using System;
using System.Linq;
using System.Collections.Generic;

namespace _2
{
    class Program
    {
       
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                string[] commandSplit = command.Split();
                if (commandSplit[0] == "Insert")
                {
                    int numb = int.Parse(commandSplit[1]);
                    int indexPosition = int.Parse(commandSplit[2]);
                    numbers.Insert(indexPosition, numb);
                }
                if (commandSplit[0] == "Delete")
                {
                    int num = int.Parse(commandSplit[1]);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == num)
                        {
                            numbers.Remove(numbers[i]);
                            i--;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
