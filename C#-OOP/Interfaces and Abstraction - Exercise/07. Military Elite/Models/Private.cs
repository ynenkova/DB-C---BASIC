using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public  class Private : Soldier,IPrivate
    {
        public Private(string firstName, string lastName, string id,decimal salary) : base(firstName, lastName, id)
        {
            this.Salary = salary;
        }

        public  decimal Salary { get; }
        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:F2}";
        }
    }
}
