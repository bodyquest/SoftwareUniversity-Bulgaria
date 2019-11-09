using System;
using System.Collections.Generic;

namespace Demo.Data
{
    public partial class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employees>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }

        public Employees Manager { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}
