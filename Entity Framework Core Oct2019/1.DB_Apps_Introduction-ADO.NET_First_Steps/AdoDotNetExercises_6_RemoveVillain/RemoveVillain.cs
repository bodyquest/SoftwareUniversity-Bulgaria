namespace AdoDotNetExercises_6_RemoveVillain
{
    using System;
    using System.Data.SqlClient;
    using AdoDotNetExercises_1_InitialSetup;

    public class RemoveVillain
    {
        public static void Main()
        {
            int villainId = int.Parse(Console.ReadLine());
            int count = 0;
            string villainName = "";

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string query =
                "SELECT [Name] FROM Villains WHERE Id = @villainId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }
                }

                count = DeletedMinionsVillainsById(villainId, connection);

                DeleteVillainById(connection, villainId);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{count} minions were released.");
            }
        }

        private static void DeleteVillainById(SqlConnection connection, int villainId)
        {
            string deleteQuery =
            @"DELETE FROM Villains
              WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.ExecuteNonQuery();
            }
        }

        private static int DeletedMinionsVillainsById(int villainId, SqlConnection connection)
        {
            int count;
            string deleteFromMinionsVillains =
                   @"DELETE FROM MinionsVillains 
                  WHERE VillainId = @villainId";

            using (SqlCommand command = new SqlCommand(deleteFromMinionsVillains, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                count = command.ExecuteNonQuery();
            }

            return count;
        }
    }
}
