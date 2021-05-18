using System;
using System.Collections.Generic;
using System.Linq;
namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var students = new List<Students>();
            for (int i = 0; i < n; i++)
            {
                string[] student = Console.ReadLine().Split();
                Students studen = new Students(student[0], student[1], student[2]);
                students.Add(studen);
            }
            students.Sort((a1,a2)=>a2.Grade.CompareTo(a1.Grade));
            Console.WriteLine(string.Join(Environment.NewLine,students));
        }
    }
    class Students
    {
        public Students(string firstName, string secondName, string grade)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Grade = grade;
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Grade { get; set; }
        public override string ToString()
        {
            return $"{this.FirstName} {this.SecondName}: {this.Grade}";
        }
    }
}
