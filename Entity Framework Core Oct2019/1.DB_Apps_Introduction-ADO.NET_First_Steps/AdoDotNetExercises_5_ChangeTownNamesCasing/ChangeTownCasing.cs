namespace AdoDotNetExercises_5_ChangeTownNamesCasing
{
    using System;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using AdoDotNetExercises_1_InitialSetup;

    public class ChangeTownCasing
    {
        public static void Main()
        {
            string country = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string updateNames =
                @"UPDATE Towns
                  SET Name = UPPER(Name)
                  WHERE CountryCode = 
                      (
                         SELECT c.Id FROM Countries AS c WHERE c.Name =         @countryName
                      )";

                using (SqlCommand command = new SqlCommand(updateNames, connection))
                {
                    command.Parameters.AddWithValue("@countryName", country);
                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine($"{rowsAffected} town names were affected.");
                }

                string townNames =
                @"SELECT t.Name 
                  FROM Towns AS t
                  JOIN Countries AS c ON c.Id = t.CountryCode
                  WHERE c.Name = @countryName";

                List<string> towns = new List<string>();

                using (SqlCommand command = new SqlCommand(townNames, connection))
                {
                    command.Parameters.AddWithValue("@countryName", country);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            towns.Add((string)reader[0]);
                        }
                    }
                }

                Console.WriteLine("[" + string.Join(", ", towns) + "]");
            }
        }
    }
}
