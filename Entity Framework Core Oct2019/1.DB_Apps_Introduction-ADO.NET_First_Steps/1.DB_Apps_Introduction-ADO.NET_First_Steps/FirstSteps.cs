namespace _1.DB_Apps_Introduction_ADO.NET_First_Steps
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    class FirstSteps
    {
        static void Main()
        {
            //string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SoftUni;Integrated Security=true";

            //int employees = 0;

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();

            //    using (SqlCommand command = new SqlCommand())
            //    {
            //        command.CommandText = "SELECT COUNT(*) FROM Employees";
            //        command.Connection = connection;

            //        employees = (int)command.ExecuteScalar();

            //    }
            //}

            //Console.WriteLine($"There are {employees} employees.");

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SoftUni;Integrated Security=true";

            IList <Employee> employees= new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT TOP (10) * FROM Employees";
                    command.Connection = connection;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee()
                            {
                                FirstName = reader["FirstName"].ToString(),
                                MiddleName = reader["MiddleName"]?.ToString(),
                                LastName = reader[2].ToString()

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
