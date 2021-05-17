using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IInformation
    {
        private string name;
        private string birthday;

        public Pet(string name, string birthDay)
        {
            this.Name = name;
            this.BirthDay = birthDay;
        }

        public string Name { get; private set; }

        public string BirthDay { get; private set; }
    }
}
