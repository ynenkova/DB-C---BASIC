using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;
        public Engineer(string firstName, string lastName, string id, decimal salary, string corps) : base(firstName, lastName, id, salary, corps)
        {
            this.repairs = new List<Repair>();
        }

        public IReadOnlyCollection<IRepair> Repairs { get; }
        public void AddRepairs(Repair repair)
        {
            this.repairs.Add(repair);
        }
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(base.ToString())
                .AppendLine("Repairs:");

            foreach (var repair in this.repairs)
            {
                builder.AppendLine(repair.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
