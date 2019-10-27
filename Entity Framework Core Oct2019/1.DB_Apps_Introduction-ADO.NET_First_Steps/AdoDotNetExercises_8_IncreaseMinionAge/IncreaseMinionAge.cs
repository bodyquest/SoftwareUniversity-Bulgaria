namespace AdoDotNetExercises_8_IncreaseMinionAge
{
    using System;
    using System.Linq;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using AdoDotNetExercises_1_InitialSetup;

    public class IncreaseMinionAge
    {
        public static void Main()
        {
            var minionIds = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<string> names = new List<string>();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string updateStatement = 
                @"UPDATE Minions
                  SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, EN(Name)), Age += 1
                  WHERE Id = @Id";


                for (int i = 0; i < minionIds.Length; i++)
                {
                    using (SqlCommand command = new SqlCommand(updateStatement, connection))
                    {
                        command.Parameters.AddWithValue("@Id", minionIds[i]);
                        command.ExecuteNonQuery();
                    }
                }

                string namesQuery = "SELECT [Name] FROM Minions";

                using (SqlCommand command = new SqlCommand(namesQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];
                            names.Add($"{name} {age}");
                        }
                    }
                }
            }

            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
