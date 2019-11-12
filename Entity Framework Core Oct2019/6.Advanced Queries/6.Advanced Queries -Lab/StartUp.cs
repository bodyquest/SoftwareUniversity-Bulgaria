namespace Demo
{
    using System;
    using Demo.Data;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Demo.Data.Queries;
    using Microsoft.Data.SqlClient;

    class StartUp
    {
        static void Main()
        {
            var price = 50000;
            ///////////////**** NATIVE SQL Query ****///////////////
            using var db = new SoftUniContext();
            var employees = db.Employees
                .FromSqlInterpolated($"SELECT * FROM dbo.Employees WHERE Salary > 50000").ToList();

            Console.WriteLine(string.Join("\n", employees.Select(e => e.FirstName + " " + e.LastName)));

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
            // this way eliminates overhead
            EmployeeQueries.ToResult(db, price);


            ///////////////**** Object State Tracking ****///////////////
            using var data = new SoftUniContext();
            var employee = db.Employees.FirstOrDefault();

            //start tracking the employee object in the db instance "data"
            data.Attach(employee);

            employee.FirstName += " pi4a";

            // stop tracking the object in this db instance "data"
            data.Entry(employee).State = EntityState.Detached;

            data.SaveChanges();


            ///////////////**** Executing a Stored Procedure ****///////////////
            // CREATE PROCEDURE UpdateAge @param int
            // AS
            // UPDATE EMployees SET Age = Age + @param

            var ageParameter = new SqlParameter("@age", 5);
            var uspQquery = "EXEC UpdateAge @age";
            db.Database.ExecuteSqlCommand(uspQquery, ageParameter);


            ///////////////**** Batch Operations ****///////////////
            // Z.EntityFramework.Plus.EFCore
            // BULK DELETE can be done this way with the package installed.

            //db.Employees
            //    .Where(u => u.FirstName == "Kiro")
            //    .Delete();

            // BULK UPDATE
            //db.Employees
            //    .Where(e => e.Salary > 20000)
            //    .Update(w => new Employees { Salary = e.Salary * 1.2m });



            ///////////////**** TYPES OF LOADING ****///////////////
            ////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////
            // By default navigation properties are not loaded

            var empl = db.Employees
                .Where(e => e.Salary > 10000)
                .FirstOrDefault();

            //EXPLICIT loading of the reference of the Employee to the Department
            db.Entry(empl)
                .Reference(e => e.Department)
                .Load();

            //EAGER loading
            var guy = db.Employees
                .Include(e => e.Department)
                .Where(e => e.Salary > 10000)
                .FirstOrDefault();

            //LAZY loading
            // Microsoft.EntityFrameworkCore.Proxies
            //in OnConfiguring() method
            // builder.UseLazyLoadingProxies().UseSqlServer(DataSettings.DefaultConnection);
            // all navigation properties of the models have to be virtual
            //convenient but generates a lot of queries so it must be used only when really needed.

            ///////////////**** CONCURRENCY CHECK ****///////////////
            //This enables "first-win" strategy

        }
    }
}
