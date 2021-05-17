using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        private string states;
        public Mission(string codeName, string states)
        {
            this.CodeName = codeName;
            this.states = states;
        }

        public string CodeName { get; private set; }

        public string States
        {
            get
            {
                return this.states;
            }
            set
            {
                if (value!= "inProgress"||value!= "Finished")
                {
                    throw new InvalidOperationException();
                }
                this.states = value;
            }
        }

        public void CompleteMission()
        {
            this.states = "Finished";
        }
        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.States}";
        }
    }
}
