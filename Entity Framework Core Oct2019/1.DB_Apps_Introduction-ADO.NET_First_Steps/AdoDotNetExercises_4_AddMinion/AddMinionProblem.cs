using AdoDotNetExercises_1_InitialSetup;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace AdoDotNetExercises_4_AddMinion
{
    public class AddMinionProblem
    {
        public static void Main()
        {
            var minionArray = Console.ReadLine().Split(": ").ToArray();
            var villainArray = Console.ReadLine().Split(": ").ToArray();

            string[] minionInfo = minionArray[1].Split(' ').ToArray();
            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string minionTown = minionInfo[2];

            string villainName = villainArray[1];

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                int? townId = GetTownByName(minionTown, connection);

                if (townId == null)
                {
                    AddTown(connection, minionTown);

                    Console.WriteLine($"Town { minionTown} was added to the database.");
                }

                townId = GetTownByName(minionTown, connection);

                AddMinion(connection, minionName, minionAge, townId);

                int? villainId = GetVillainByName(villainName, connection);

                if (villainId == null)
                {
                    AddVillain(connection, villainName);

                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                villainId = GetVillainByName(villainName, connection);

                int minionId = GetMinionByName(connection, minionName);
                AddMinionVillain(connection, villainId, minionId);

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private static void AddMinionVillain(SqlConnection connection, int? villainId, int minionId)
        {
            string insertStatement =
           @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
            using (SqlCommand command = new SqlCommand(insertStatement, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.Parameters.AddWithValue("@minionId", minionId);
                command.ExecuteNonQuery();
            }
        }

        private static int GetMinionByName(SqlConnection connection, string minionName)
        {
            string minionQuery = "SELECT Id FROM Minions WHERE Name = @name";

            using (SqlCommand command = new SqlCommand(minionQuery, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);
                return (int)command.ExecuteScalar();
            }
        }

        private static void AddVillain(SqlConnection connection, string villainName)
        {
            string insertStatement =
           @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
            using (SqlCommand command = new SqlCommand(insertStatement, connection))
            {
                command.Parameters.AddWithValue("@villainName", villainName);
                command.ExecuteNonQuery();
            }
        }

        private static int? GetVillainByName(string villainName, SqlConnection connection)
        {
            string villainIdQuery = "SELECT Id FROM Villains WHERE Name = @name";

            using (SqlCommand command = new SqlCommand(villainIdQuery, connection))
            {
                command.Parameters.AddWithValue("@name", villainName);
                return (int?)command.ExecuteScalar();
            }
        }

        private static void AddMinion(SqlConnection connection, string minionName, int minionAge, int? townId)
        {
            string insertStatement =
            @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            using (SqlCommand command = new SqlCommand(insertStatement, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);
                command.Parameters.AddWithValue("@age", minionAge);
                command.Parameters.AddWithValue("@townId", townId);

                command.ExecuteNonQuery();
            }


        }

        private static int? GetTownByName(string minionTown, SqlConnection connection)
        {
            string townIdQuery = "SELECT Id FROM Towns WHERE Name = @name";

            using (SqlCommand command = new SqlCommand(townIdQuery, connection))
            {
                command.Parameters.AddWithValue("@name", minionTown);
                return (int?)command.ExecuteScalar();
            }
        }

        private static void AddTown(SqlConnection connection, string minionTown)
        {
            string insertStatement =
            @"INSERT INTO Towns (Name) VALUES (@name)";
            using (SqlCommand command = new SqlCommand(insertStatement, connection))
            {
                command.Parameters.AddWithValue("@name", minionTown);
                command.ExecuteNonQuery();
            }
        }
    }
}
