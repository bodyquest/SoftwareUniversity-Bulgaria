namespace Demo
{
    using System;
    using Demo.Data;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Demo.Data.Queries;

    class StartUp
    {
        static void Main()
        {
            var price = 50000;
            ///////////////**** NATIVE SQL Query ****///////////////
            using var db = new SoftUniContext();
            var employees = db.Employees
                .FromSqlInterpolated($"SELECT * FROM dbo.Employees WHERE Salary > 50000").ToList();

            Console.WriteLine(string.Join("\n", employees.Select(e => e.FirstName + " "+ e.LastName)));

            ///////////////**** Compiled Queries ****///////////////
            // Improve the queries further in performance as they already save compiling the query by EF.

            db.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new Result
                {
                    FullName = e.FirstName + " " + e.LastName
                });

            var query = EF.CompileQuery<SoftUniContext, IEnumerable<Result>>(db =>
            db.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new Result
                {
                    FullName = e.FirstName + " " + e.LastName
                }));

            //** Compiled Query called from a class with one parameter "int" **//
            EmployeeQueries.ToResult(db, price);


            ///////////////**** Object State Tracking ****///////////////
            using var data = new SoftUniContext();
            var employee = db.Employees.FirstOrDefault();

            employee.FirstName += " pi4a";
            data.SaveChanges();
        }
    }
}
