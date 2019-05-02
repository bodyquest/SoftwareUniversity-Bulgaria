namespace EXRC_Company_Roster
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Employee
    {
        private const int defaultAge = -1;
        private const string defaultEmail = "n/a";

        public Employee(string name, double salary, string position, string department, string email, int age)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = email;
            this.Age = age;
        }

        public Employee(string name, double salary, string position, string department, string email)
            :this( name,  salary,  position,  department,  email, defaultAge)
        {
        }

        public Employee(string name, double salary, string position, string department, int age)
            : this(name, salary, position, department, defaultEmail, age)
        {
        }

        public Employee(string name, double salary, string position, string department)
            : this(name, salary, position, department, defaultEmail, defaultAge)
        {
        }

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Salary} {this.Email} {this.Age}";
        }
    }
}
