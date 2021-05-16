using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ClassroomProject
{
   public class Classroom
    {
        private List<Student> students;
        

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count => this.students.Count;
        public string RegisterStudent(Student student)
        {
            if (this.Capacity>this.students.Count)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            var student = this.students.FirstOrDefault(x => x.FirstName == firstName&& x.LastName==lastName);
            if (student==null)
            {
                return "Student not found";
            }
            this.students.Remove(student);
            return $"Dismissed student {firstName} {lastName}";
        }
        public string GetSubjectInfo(string subject)
        {
            var stud = this.students.Where(x => x.Subject == subject);
            if (stud.Count()>0)
            {
                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var item in stud)
                {
                    sb.AppendLine($"{item.FirstName} {item.LastName}");
                }
                return sb.ToString().TrimEnd().TrimStart();
            }
            return "No students enrolled for the subject";
        }
       public int GetStudentsCount()
        {
            return this.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            return this.students.First(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
