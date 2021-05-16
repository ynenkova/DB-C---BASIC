using System;
using System.Collections.Generic;
namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            var command = Console.ReadLine();
            while (command != "END")
            {
                var tokens = command.Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var town = tokens[2];

                people.Add(new Person(name, age, town));
                command = Console.ReadLine();
            }
            int index = int.Parse(Console.ReadLine());
            Person person = people[index - 1];
            int equal = 0;
            int noEqual = 0;
            foreach (Person item in people)
            {
                int res = person.CompareTo(item);
                if (res < 0)
                {
                    noEqual++;
                }
                else if (res > 0)
                {
                    noEqual++;
                }
                else
                {
                    equal++;
                }
            }
            if (equal == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {noEqual} {people.Count}");
            }
        }
    }
}
