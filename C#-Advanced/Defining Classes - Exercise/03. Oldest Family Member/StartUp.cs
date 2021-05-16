using System;
using System.Linq;

namespace Oldest_Family_Member
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] membersArg = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = membersArg[0];
                int age = int.Parse(membersArg[1]);
                var person = new Person(name, age);
                family.AddMember(person);
            }
            Console.WriteLine(family.GetOldestMember());
        }
    }
}
