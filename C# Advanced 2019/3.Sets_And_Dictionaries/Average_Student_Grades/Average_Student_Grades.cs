using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < num; i++)
            {
                string[] studetnInfo = Console.ReadLine().Split(" ");
                string student = studetnInfo[0];
                double grade = double.Parse(studetnInfo[1]);

                if (!students.ContainsKey(student))
                {
                    students[student] = new List<double>();
                    students[student].Add(grade);
                }
                else
                {
                    students[student].Add(grade);
                }
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value)} (avg: {student.Value.Average():f2})");
            }
        }
    }
}
 