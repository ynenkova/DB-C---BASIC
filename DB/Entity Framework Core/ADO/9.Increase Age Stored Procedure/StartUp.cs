using System;
using System.Data.SqlClient;
namespace _9.Increase_Age_Stored_Procedure
{
   public class StartUp
    {
        private static string connectionString = "Server=LAPTOP-EJ1MT1A4; Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var id =int.Parse( Console.ReadLine());
            using (connection)
            {
                
                using var commandProcedure = new SqlCommand(@"usp_GetOlder", connection);
                commandProcedure.Parameters.AddWithValue("@id", id);
                commandProcedure.CommandType =System.Data.CommandType.StoredProcedure;
              commandProcedure.ExecuteNonQuery();

                var printQuery = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
                using var select = new SqlCommand(printQuery, connection);
                select.Parameters.AddWithValue("@id", id);

                var reader = select.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{(string)reader["Name"]} - {reader["Age"]} years old");
                    }
                }
            }
        }
    }
}
