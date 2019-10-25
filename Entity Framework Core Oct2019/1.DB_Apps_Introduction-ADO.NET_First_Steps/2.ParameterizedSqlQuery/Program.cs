namespace _2.ParameterizedSqlQuery
{
    using _1.DB_Apps_Introduction_ADO.NET_First_Steps;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SoftUni;Integrated Security=true";

            IList<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT TOP (10) * FROM Employees WHERE DepartmentID = @depId";
                    command.Connection = connection;

                    //SqlParameter param = new SqlParameter();
                    //param.DbType = System.Data.DbType.Int32;
                    //param.ParameterName = "@depId";
                    //param.Value = 7;

                    command.Parameters.AddWithValue("@depId", 7);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee()
                            {
                                FirstName = reader["FirstName"]?.ToString(),
                                MiddleName = reader["MiddleName"]?.ToString(),
                                LastName = reader[2]?.ToString()

                            });
                        }
                    }
                }
            }

            foreach (var item in employees)
            {
                Console.WriteLine($"{item.FirstName} {item.MiddleName} {item.LastName}");
            }
        }
    }
}
