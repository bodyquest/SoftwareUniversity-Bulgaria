using System;
using System.Collections.Generic;

namespace Demo.Data
{
    public partial class EmployeesProjects
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public Employees Employee { get; set; }
        public Projects Project { get; set; }
    }
}
