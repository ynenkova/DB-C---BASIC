using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> privates;
        public LieutenantGeneral(string firstName, string lastName, string id, decimal salary) : base(firstName, lastName, id, salary)
        {
            this.privates = new List<Private>();
        }

        public IReadOnlyCollection<IPrivate> Privates { get => this.privates; }
        public void AddPrivet(Private @private)
        {
            this.privates.Add(@private);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Private:");
            foreach (var current in this.privates)
            {
                sb.AppendLine(" " + current.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
