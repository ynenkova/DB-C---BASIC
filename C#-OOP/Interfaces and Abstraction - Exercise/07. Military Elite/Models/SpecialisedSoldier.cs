using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public  class SpecialisedSoldier : Private,ISpecialisedSoldier
    {
        private string corps;
        protected SpecialisedSoldier(string firstName, string lastName, string id, decimal salary,string corp) : base(firstName, lastName, id, salary)
        {
            this.corps = corp;
        }

        public string Corps
        {
            get
            {
                return this.corps;
            }
            set
            {
                if (value!= "Airforces"||value!= "Marines")
                {
                    throw new InvalidOperationException();
                }
                this.corps = value;
            }
        }
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corps}");

            return builder.ToString().TrimEnd();
        }
    }
}
