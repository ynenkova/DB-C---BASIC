using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_4._Opinion_Poll
{
   public class Family
    {
        private HashSet<Person> people;
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
