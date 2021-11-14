using System;
using System.Data.SqlClient;
namespace _4._Add_Minion
{
    public class StartUp
    {
        private static string connectionString = "Server=LAPTOP-EJ1MT1A4; Database=MinionsDB;Integrated Security=true";

        private static string minionnSelect = @"SELECT Id FROM Minions WHERE Name = @Name";
        private static string villainSelect = @"SELECT Id FROM Villains WHERE Name = @Name";
        private static string townSelect = @"SELECT Id FROM Towns WHERE Name = @townName";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var minion = Console.ReadLine().Split(' ');
            var nameMinion = minion[1];
            var ageMinion = int.Parse(minion[2]);
            var town = minion[3];
            var villain = Console.ReadLine().Split();
            var villainName = villain[1];

            
            using (connection)
            {
              
                using var findTown = new SqlCommand(townSelect, connection);
                findTown.Parameters.AddWithValue("@townName", town);
                var result = findTown.ExecuteScalar();
                if (result == null)
                {
                    var insertTown = @"INSERT INTO Towns (Name) VALUES (@townName)";
                    using var insert = new SqlCommand(insertTown, connection);
                    insert.Parameters.AddWithValue("@townName", town);
                    insert.ExecuteNonQuery();
                    Console.WriteLine($"Town {town} was added to the database.");
                }

                using var findVillain = new SqlCommand(villainSelect, connection);
                findVillain.Parameters.AddWithValue("@Name", villainName);
                result = findVillain.ExecuteScalar();
                if (result == null)
                {
                    var evilnessFactors = 4;
                    var insertVillainMessages = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, @evilFactory)";
                    using var insertVillain = new SqlCommand(insertVillainMessages, connection);
                    insertVillain.Parameters.AddWithValue("@villainName", villainName);
                    insertVillain.Parameters.AddWithValue("@evilFactory", evilnessFactors);
                    insertVillain.ExecuteNonQuery();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                using var commandMinion = new SqlCommand(minionnSelect, connection);
                commandMinion.Parameters.AddWithValue("@Name", nameMinion);
                commandMinion.ExecuteScalar();

                if (commandMinion==null)
                {
                   
                    using var commandTown = new SqlCommand(townSelect, connection);
                    var townId = commandTown.ExecuteScalar();

                    var insertMinionText = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)";
                    using var insertMinion = new SqlCommand(insertMinionText, connection);
                    insertMinion.Parameters.AddWithValue("@nam", nameMinion);
                    insertMinion.Parameters.AddWithValue(" @age", ageMinion);
                    insertMinion.Parameters.AddWithValue("@townId", townId);
                    insertMinion.ExecuteNonQuery();
                }
                else
                {
                   using var commandMinId = new SqlCommand(minionnSelect, connection);
                    commandMinId.Parameters.AddWithValue("@Name", nameMinion);
                    var minionId =(int) commandMinId.ExecuteScalar();

                    using var commandVilllan = new SqlCommand(villainSelect, connection);
                    commandVilllan.Parameters.AddWithValue("@Name", villainName);
                    var villainId = commandVilllan.ExecuteScalar();

                    
                    var text = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
                    using var minionVillain = new SqlCommand(text, connection);
                    minionVillain.Parameters.AddWithValue("@villainId", villainId);
                    minionVillain.Parameters.AddWithValue("@minionId",minionId);
                   
                    minionVillain.ExecuteNonQuery();
                    Console.WriteLine($"Successfully added {nameMinion} to be minion of {villainName}.");

                }

            }


        }
    }
}
