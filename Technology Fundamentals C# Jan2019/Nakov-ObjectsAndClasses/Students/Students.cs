using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
    }

    class Students
    {
        static void Main(string[] args)
        {
            var individualStudent = Console.ReadLine().Split(' ').ToList();
            List<Student> studentList = new List<Student>();
            while (individualStudent[0] != "end")
            {
                string first = individualStudent[0];
                string last = individualStudent[1];
                int age = int.Parse(individualStudent[2]);
                string town = individualStudent[3];

                Student person = new Student();
                person.FirstName = first;
                person.LastName = last;
                person.Age = age;
                person.Hometown = town;
                studentList.Add(person);

                individualStudent = Console.ReadLine().Split(' ').ToList();
            }

            string city = Console.ReadLine();
            foreach (Student person in studentList)
            {
                if (person.Hometown == city)
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName} is {person.Age} years old.");
                }
            }
        }
    }
}
