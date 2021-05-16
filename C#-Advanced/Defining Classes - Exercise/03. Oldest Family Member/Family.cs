using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oldest_Family_Member
{
    public  class Family
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
        public Person GetOldestMember()
        {
            Person isBigger = people.OrderByDescending(x => x.Age).FirstOrDefault();
            return isBigger;
        }
    }
}
