using System;
using System.Linq;
using System.Collections.Generic;
 
public class Program
{
    public static void Main()
    {
        List<string> input = Console.ReadLine()
            .Split(':')
            .Select(s => s.Trim())
            .ToList();
 
        var Courses = new Dictionary<string, List<string>>();
        var studentNames = new List<string>();
 
 
        while (true)
        {
            var courseName = input[0];
 
            if (courseName == "end")
            {
                break;
            }
            var studentName = input[1];
 
            if (!Courses.ContainsKey(courseName))
            {
                Courses.Add(courseName, studentNames);
                studentNames.Add(studentName);
                studentNames = new List<string>();
            }
            else
            {
                Courses[courseName].Add(studentName);
            }
 
            input = Console.ReadLine()
            .Split(':')
            .Select(s => s.Trim())
            .ToList();
        }
 
        foreach (var course in Courses
               .OrderByDescending(x => x.Value.Count))              
        {
            Console.WriteLine("{0}: {1}", course.Key, course.Value.Count);
 
                   
            foreach (var name in course.Value.OrderBy(n => n))
            {
                Console.WriteLine("-- {0}", name);
            }
        }
    }
}
