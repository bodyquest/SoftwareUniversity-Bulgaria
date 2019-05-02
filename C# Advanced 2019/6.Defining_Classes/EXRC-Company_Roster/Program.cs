using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Company_Roster
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> employeeList = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                var employee = Console.ReadLine().Split(' ').ToArray();
                string name = employee[0];
                double salary = double.Parse(employee[1]);
                string position = employee[2];
                string department = employee[3];
                Employee person = null;

                if (employee.Length == 6)
                {
                    string email = employee[4];
                    int age = int.Parse(employee[5]);
                    person = new Employee(name, salary, position, department, email, age);
                }
                else if(employee.Length == 5)
                {
                    bool isAge = int.TryParse(employee[4], out int age);

                    if (isAge)
                    {
                        person = new Employee(name, salary, position, department, age);
                    }
                    else
                    {
                        person = new Employee(name, salary, position, department, employee[4]);
                    }
                }
                else
                {
                    // TO DO (if length == 4)
                }

                employeeList.Add(person);
            }

            //TO DO: Filter highest average salary DEPARTMENT
            // Use Dictionary <string department, int totalSalaries>



        }
            


        }
    }
}
