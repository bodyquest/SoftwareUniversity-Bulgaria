namespace AdoDotNetExercises_9_IncreaseAgeStoredProcedure
{
    using System;
    using System.Data.SqlClient;
    using AdoDotNetExercises_1_InitialSetup;

    public class IncreaseAge_usp
    {
        public static void Main()
        {
            int Id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string createProcedure =
                @"CREATE PROC usp_GetOlder @id INT
                  AS
                  UPDATE Minions
                     SET Age += 1
                  WHERE Id = @id";

                using (SqlCommand command = new SqlCommand(createProcedure, connection))
                {
                    command.Parameters.AddWithValue("@id", Id);
                    command.ExecuteNonQuery();
                }

                string uspGetOlderProc = "EXEC usp_GetOlder @id";

                using (SqlCommand command = new SqlCommand(uspGetOlderProc, connection))
                {
                    command.Parameters.AddWithValue("@id", Id);
                    command.ExecuteNonQuery();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        string name = (string)reader[0];
                        int age = (int)reader[1];

                        Console.WriteLine($"{name} - {age} years old");
                    }
                }
            }
        }
    }
}
