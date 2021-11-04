using P01_HospitalDatabase.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace P01_HospitalDatabase
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            var db = new HospitalContext();
           
           db.Database.Migrate();
        }
    }
}
