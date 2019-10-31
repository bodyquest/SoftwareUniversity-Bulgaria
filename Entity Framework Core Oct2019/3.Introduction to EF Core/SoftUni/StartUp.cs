namespace SoftUni
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using SoftUni.Data;
    using SoftUni.Models;

    public class StartUp
    {
        public static void Main()
        {
            // .\SQLEXPRESS
            using (var context = new SoftUniContext())
            {
                //var result = GetEmployeesFullInformation(context);
                //var result = GetEmployeesWithSalaryOver50000(context);
                //var result = GetEmployeesFromResearchAndDevelopment(context);
                //var result = AddNewAddressToEmployee(context);
                //var result = GetEmployeesInPeriod(context);
                //var result = GetAddressesByTown(context);
                //var result = GetEmployee147(context);
                
                var result = GetDepartmentsWithMoreThan5Employees(context);
                Console.WriteLine(result);
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                    e.EmployeeId
                })
                .OrderBy(x => x.EmployeeId)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary,
                    e.EmployeeId
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Department = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} {e.Department} - ${e.Salary:F2}");
            }

            return result.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);

            var nakov = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");
            nakov.Address = address;

            context.SaveChanges();

            var employeeAddresses = context.Employees
                .OrderByDescending(a => a.AddressId)
                .Select(a => a.Address.AddressText)
                .Take(10)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var adr in employeeAddresses)
            {
                result.AppendLine(adr);
            }

            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(p => p.EmployeesProjects.Any(s =>
                                                    s.Project.StartDate.Year >= 2001 &&
                                                    s.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeFullName = e.FirstName + " " + e.LastName,
                    ManagerFullName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    }).ToList()
                })
                .Take(10)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.EmployeeFullName} - Manager: {employee.ManagerFullName}");
                foreach (var project in employee.Projects)
                {
                    var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt");
                    var endDate = project.EndDate.HasValue ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";

                    result.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }

            return result.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .Select(a => new
                {
                    EmployeeCount = a.Employees.Count,
                    Address = a.AddressText,
                    TownName = a.Town.Name
                })
                .Take(10)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var address in addresses)
            {
                result.AppendLine($"{address.Address}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return result.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                    }).ToList()

                })
                .Single();

            StringBuilder result = new StringBuilder();
            result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var project in employee.Projects.OrderBy(p=> p.ProjectName))
            {
                result.AppendLine($"{project.ProjectName}");
            }

            return result.ToString().TrimEnd();
        }



        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .OrderBy(d => d.Employees.Count)
                .



            StringBuilder result = new StringBuilder();
            
            foreach (var department in departments)
            {
                result.AppendLine($"");
            }

            return result.ToString().TrimEnd();
        }
    }
}