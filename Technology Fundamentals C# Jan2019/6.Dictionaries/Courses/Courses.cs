using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    class Courses
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] course = input.Split(' ').ToArray();
                string courseName = course[0];
                string student = course[1];
                if (!courses.ContainsKey(courseName))
                {
                    courses[courseName] = new List<string>();
                    courses[courseName].Add(student);
                }
                else
                {
                    courses[courseName].Add(student);
                }

                input = Console.ReadLine();
            }
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
