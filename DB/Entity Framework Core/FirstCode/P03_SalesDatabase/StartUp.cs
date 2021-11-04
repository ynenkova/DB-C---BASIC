using System;
using P03_SalesDatabase.Data;
using Microsoft.EntityFrameworkCore;
namespace P03_SalesDatabase
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            var db = new SalesContext();
            db.Database.Migrate();
        }
    }
}
