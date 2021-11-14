using System;
using System.Data.SqlClient;
namespace _8._Increase_Minion_Age
{
    public class StartUp
    {
        private static string connectionString = "Server=LAPTOP-EJ1MT1A4; Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            string[] ids = Console.ReadLine().Split();

            using (connection)
            {

                for (int i = 0; i < ids.Length; i++)
                {
                    using var updateMinions = new SqlCommand(@"UPDATE Minions
                                                          SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                                          WHERE Id = @Id", connection);
                    var id = ids[i];
                    updateMinions.Parameters.AddWithValue("@Id", id);
                    updateMinions.ExecuteNonQuery();
                }



                using var nameAge = new SqlCommand(@"SELECT Name, Age FROM Minions", connection);
                var reader = nameAge.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{(string)reader["Name"]} {reader["Age"]}");
                    }
                }
            }
        }
    }
}
