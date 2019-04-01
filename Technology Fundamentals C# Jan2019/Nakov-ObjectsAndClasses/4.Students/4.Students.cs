using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> studentList = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ");
                Student person = new Student();
                person.FirstName = command[0];
                person.LastName = command[1];
                person.Grade = double.Parse(command[2]);
                studentList.Add(person);
            }
            List<Student> sortedList = studentList.OrderByDescending(p => p.Grade).ToList();
            Console.WriteLine(string.Join("\r\n", sortedList));
        }
    }
}
