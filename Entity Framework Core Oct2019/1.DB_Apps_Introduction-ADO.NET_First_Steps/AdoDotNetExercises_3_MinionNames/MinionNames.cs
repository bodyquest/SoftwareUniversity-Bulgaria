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


            }
        }
    }
}
