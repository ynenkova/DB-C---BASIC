using System;
using System.Data.SqlClient;
namespace _3._Minion_Names
{
    public class StartUp

    {
        private static string connection = "Server=LAPTOP-EJ1MT1A4; Database=MinionsDB;Integrated Security=true";

        static void Main(string[] args)
        {
            var sqlconn = new SqlConnection(connection);
            sqlconn.Open();

            var id = int.Parse(Console.ReadLine());
            using (sqlconn)
            {
                var text = @"SELECT Name FROM Villains WHERE Id = @Id";

               using var commandId = new SqlCommand(text, sqlconn);
                commandId.Parameters.AddWithValue("@Id", id);
                var result =(string) commandId.ExecuteScalar();
               

                if (result==null)
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                }
                else
                {
                    var queryMinions = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
                    var minions = new SqlCommand(queryMinions, sqlconn);
                    minions.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = minions.ExecuteReader();
                    using (reader)
                    {
                        Console.WriteLine($"Villain:{result}");
                        int rowCount = 1;
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{rowCount++}. {reader[1]} {reader[2]}");
                            }
                        }
                    }
                }
            }


        }
    }
}
