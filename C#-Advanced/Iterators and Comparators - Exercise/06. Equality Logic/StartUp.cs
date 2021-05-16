using System;
using System.Collections.Generic;
namespace EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> peopleFirst = new SortedSet<Person>();
            HashSet<Person> peopleHashSet = new HashSet<Person>();

            
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                Person newPerson = new Person(name, age);

                peopleFirst.Add(newPerson);
                peopleHashSet.Add(newPerson);
            }

            Console.WriteLine(peopleFirst.Count);
            Console.WriteLine(peopleHashSet.Count);
        }
    }
}
