using System;
using System.Data.SqlClient;
namespace _2._Villain_Names
{
    public class StartUp
    {
        private static string connectionStringMinions = "Server=LAPTOP-EJ1MT1A4; Database=MinionsDB;Integrated Security=true";
        private static SqlConnection connection = new SqlConnection(connectionStringMinions);
        static void Main(string[] args)
        {
            connection.Open();

            using (connection)
            {
                string text = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                FROM Villains AS v 
                                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                GROUP BY v.Id, v.Name 
                                HAVING COUNT(mv.VillainId) > 3 
                                ORDER BY COUNT(mv.VillainId)";
                var command = new SqlCommand(text, connection);
              SqlDataReader reader=  command.ExecuteReader();
                using (reader)
                {

                    while(reader.Read())
                    {
                        Console.WriteLine(reader["Name"]+" - "+ reader["MinionsCount"]);
                    }
                }
             }
        }
    }
}
