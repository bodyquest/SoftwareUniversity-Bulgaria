namespace AdoDotNetExercises_2_VillainNames
{
    using AdoDotNetExercises_1_InitialSetup;
    using System;
    using System.Data.SqlClient;

    public class VillainNames
    {
        public static void Main()
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string sqlQuery = 
                @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                      FROM Villains AS v 
                      JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                  GROUP BY v.Id, v.Name 
                    HAVING COUNT(mv.VillainId) > 3 
                  ORDER BY COUNT(mv.VillainId)";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int count = (int)reader[1];

                            Console.WriteLine($"{name} - {count}");
                        }
                    }
                }
            }
        }
    }
}
