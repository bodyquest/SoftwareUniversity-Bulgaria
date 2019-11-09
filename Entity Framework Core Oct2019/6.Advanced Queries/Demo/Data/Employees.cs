using System;
using System.Collections.Generic;

namespace Demo.Data
{
    public partial class Employees
    {
        public Employees()
        {
            Departments = new HashSet<Departments>();
            EmployeesProjects = new HashSet<EmployeesProjects>();
            InverseManager = new HashSet<Employees>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string JobTitle { get; set; }
        public int DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public int? AddressId { get; set; }

        public Addresses Address { get; set; }
        public Departments Department { get; set; }
        public Employees Manager { get; set; }
        public ICollection<Departments> Departments { get; set; }
        public ICollection<EmployeesProjects> EmployeesProjects { get; set; }
        public ICollection<Employees> InverseManager { get; set; }
    }
}
