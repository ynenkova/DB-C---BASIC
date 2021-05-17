using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;
        public Commando(string firstName, string lastName, string id, decimal salary, string corps) : base(firstName, lastName, id, salary, corps)
        {
            this.missions = new List<Mission>();
        }

        public IReadOnlyCollection<IMission> Missions => this.missions;
        public void AddMission(Mission mission)
        {
            this.missions.Add(mission);
        }
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(base.ToString())
                .AppendLine("Missions:");

            this.missions
                .ForEach(m => builder.AppendLine(m.ToString()));

            return builder.ToString().TrimEnd();
        }
    }
}
