using System;


namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {
        }
        public override int Age
        {
            get => base.Age;
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException("Age can't be greder then 15");
                }
                base.Age = value;
            }
        }

    }
}
