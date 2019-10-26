namespace AdoDotNetExercises_3_MinionNames
{
    using System;
    using System.Data.SqlClient;
    using AdoDotNetExercises_1_InitialSetup;

    public class MinionNames
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string villainNameQuery = $"SELECT Name FROM Villains WHERE Id = @id";

                using (SqlCommand command = new SqlCommand(villainNameQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        command.Parameters.AddWithValue(@"id", input);
                        string villainName = (string)command.ExecuteScalar();

                        if (villainName == null)
                        {
                            Console.WriteLine($"No villain with ID {input} exists in the database.");
                            return;
                        }

                        Console.WriteLine($"Villain: {villainName}");
                    }
                }

                string minionsQuery =
                @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

                using (SqlCommand command = new SqlCommand(minionsQuery, connection))
                {
                    command.Parameters.AddWithValue("Id", input);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {  
                            long rowNum = (long)reader[0];
                            string name = (string)reader[1];
                            int age = (int)reader[2];

                            Console.WriteLine($"{rowNum}. {name} {age}");
                        }

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("no minions");
                        }
                    }
                }
            }
        }
    }
}
