using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            using var db = new FootballBettingContext();
            db.Database.EnsureCreated();
        }
    }
}
