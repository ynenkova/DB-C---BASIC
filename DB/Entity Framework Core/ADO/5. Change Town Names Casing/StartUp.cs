using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace _5._Change_Town_Names_Casing
{
    public class StartUp
    {
        private static string connectionString = "Server=LAPTOP-EJ1MT1A4; Database=MinionsDB;Integrated Security=true";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var country = Console.ReadLine();
            using (connection)
            {

               
               using var updateTowns = new SqlCommand(@"UPDATE Towns
                           SET Name = UPPER(Name)
                           WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)",connection);
                updateTowns.Parameters.AddWithValue("@countryName", country);
                int isTown = updateTowns.ExecuteNonQuery();

                if (isTown == 0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    
                    using SqlCommand select = new SqlCommand(@"SELECT t.Name 
                             FROM Towns as t
                             JOIN Countries AS c ON c.Id = t.CountryCode
                             WHERE c.Name = @countryName", connection);
                    select.Parameters.AddWithValue("@countryName", country);

                    var reader = select.ExecuteReader();

                    var listTowns = new List<string>();

                    List<string> towns = new List<string>();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var name = reader["Name"].ToString();
                            listTowns.Add(name);
                        }

                        Console.WriteLine($"{listTowns.Count} town names were affected.");
                        Console.WriteLine($"[{string.Join(",", listTowns)}]");
                    }
                }

            }

        }
    }
}
