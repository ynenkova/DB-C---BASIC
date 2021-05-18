using System;
using System.Linq;
using System.Collections.Generic;
namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                string[] commandSplit = command.Split();

                if (commandSplit[0] == "Add")
                {
                    int num = int.Parse(commandSplit[1]);
                    numbers.Add(num);
                }
                else
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        int numb = int.Parse(commandSplit[0]);
                        int sum = numbers[i] + numb;
                        if (sum <= maxCapacity)
                        {
                            numbers[i] += numb;
                            break;
                        }

                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
