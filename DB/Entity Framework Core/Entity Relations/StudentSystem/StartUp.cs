using P01_StudentSystem.Data.Models;
using System;

namespace P01_StudentSystem
{
    class StartUp
    {
       public static void Main(string[] args)
        {
            using var db = new StudentSystemContext();
            db.Database.EnsureCreated();
        }
    }
}
