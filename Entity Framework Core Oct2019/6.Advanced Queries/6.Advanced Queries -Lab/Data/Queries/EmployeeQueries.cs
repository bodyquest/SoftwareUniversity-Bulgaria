using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data.Queries
{
    public class EmployeeQueries
    {
        public static Func<SoftUniContext, int, IEnumerable<Result>> ToResult 
            = EF.CompileQuery<SoftUniContext, int, IEnumerable<Result>>((db, price) =>
            db.Employees
                .Where(e => e.Salary > price)
                .Select(e => new Result
                {
                    FullName = e.FirstName + " " + e.LastName
                }));
    }
}
