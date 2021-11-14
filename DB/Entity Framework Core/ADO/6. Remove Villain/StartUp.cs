using System;
using System.Data.SqlClient;
namespace _6._Remove_Villain
{
    public class StartUp
    {
        private static string connectionString = "Server=LAPTOP-EJ1MT1A4; Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var villainId = int.Parse(Console.ReadLine());

            using SqlTransaction transaction= connection.BeginTransaction();
            using (connection)
            {
                try
                {

                    var text = @"SELECT Name FROM Villains WHERE Id = @villainId";
                    using SqlCommand findVillain = new SqlCommand(text, connection);
                    findVillain.Parameters.AddWithValue("@villainId", villainId);
                    findVillain.Transaction = transaction;

                    var result = findVillain.ExecuteScalar();
                    if (result == null)
                    {
                        throw new NullReferenceException("No such villain was found.");
                    }
                    else
                    {

                        var releasesMinion = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                        using var releases = new SqlCommand(releasesMinion, connection);
                        releases.Parameters.AddWithValue("@villainId", villainId);
                        releases.Transaction = transaction;
                        int affected = releases.ExecuteNonQuery();

                        var deleteVillain = @"DELETE FROM Villains WHERE Id = @villainId";
                        using var delete = new SqlCommand(deleteVillain, connection);
                        delete.Parameters.AddWithValue("@villainId", villainId);
                        delete.Transaction = transaction;
                        delete.ExecuteNonQuery();

                        transaction.Commit();

                        Console.WriteLine($"{(string)result} was deleted.");
                        Console.WriteLine($"{affected} minions were relased.");
                    }
                }
                catch (NullReferenceException e)
                {
                    try
                    {
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                    catch (Exception m)
                    {

                        Console.WriteLine(m.Message);
                    }
                    
                }
            }
        }
    }
}

