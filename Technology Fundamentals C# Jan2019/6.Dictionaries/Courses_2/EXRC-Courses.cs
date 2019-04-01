using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Courses_2
{
    static void Main()
    {
        var courses = new Dictionary<string, List<string>>();

        string input = Console.ReadLine();
        while (input != "end")
        {
            string[] course = input.Split(" : ").ToArray();
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
        courses = courses.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, y => y.Value);
        foreach (var course in courses)
        {
            var list = course.Value;

            Console.WriteLine($"{course.Key}: {course.Value.Count}");
            list = list.OrderBy(x => x).ToList();
            foreach (var student in list)
            {
                Console.WriteLine($"-- {student}");
            }
        }
    }
}

