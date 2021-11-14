using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace _7._Print_All_Minion_Names
{
    public class StartUp
    {
        private static string connectionString = "Server=LAPTOP-EJ1MT1A4; Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                var text = @"SELECT Name FROM Minions";

                using var selectName = new SqlCommand(text, connection);
                var reader = selectName.ExecuteReader();
                var list = new List<string>();
                using (reader)
                {
                    while (reader.Read())
                    {
                        list.Add((string)reader["Name"]);
                    }
                }
                for (int i = 0; i < list.Count / 2; i++)
                {
                    
                        Console.WriteLine(list[i]);
                    Console.WriteLine(list[list.Count - i - 1]);

                }
                if (list.Count / 2 != 0)
                {
                    Console.WriteLine(list[list.Count / 2]);
                }
            }
        }
    }
}
