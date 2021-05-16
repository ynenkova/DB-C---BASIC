using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
   public class Family
    {
        public HashSet<Person> people;
        public Family()
        {
            this.people = new HashSet<Person>();
        }
        public void AddMember(Person people)
        {
            this.people.Add(people);
        }
        public HashSet<Person> GetOldPeoples()
        {
            return this.people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToHashSet();
        }
    }
}
