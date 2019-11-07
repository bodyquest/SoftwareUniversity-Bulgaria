namespace P01_StudentSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using P01_StudentSystem.Data;
    using P01_StudentSystem.Data.Models;
    public class SartUp
    {
        public static void Main()
        {
            //Students
            string[] firstNames =
            {
                "Ivan",
                "Gosho",
                "Petar",
                "Misho"
            };

            string[] lastNames =
            {
                "Kyumurchiev",
                "Karabiberov",
                "Kodjabashev",
                "Ivanov"
            };

            //Courses
            string[] courseNames =
            {
                    "Basics",
                    "Fundamentals",
                    "Advanced",
                    "OOP",
                    "Databases",
                    "EF Core"
                };

            string[] languages =
            {
                    "C#",
                    "Java",
                    "Python",
                    "PHP",
                    "JavaScript"
                };

            List<Student> students = GenerateStudents(firstNames, lastNames);
            List<Course> allCourses = GenerateCourses(courseNames, languages);

            using (var db = new StudentSystemContext())
            {
                List<Student> studentsFromDb = db.Students.ToList();
                List<Course> coursessFromDb = db.Courses
                    .ToList();

                Random rnd = new Random();

                for (int i = 0; i < 15; i++)
                {
                    var randomId = rnd.Next(0, coursessFromDb.Count);
                    var course = coursessFromDb[randomId];
                    var resource = new Resource
                    {
                        Name = $"Lecture {i} from {course.Name}",
                        Url = $"www.softuni.bg/{course.Name}/Lecture{1}{course.Name}",
                        ResourceType = ResourceType.Video,
                        Course = course
                    };

                    db.Resources.Add(resource);
                }

                HashSet<int> studentIds = new HashSet<int>();
                HashSet<int> courseIds = new HashSet<int>();

                List<KeyValuePair<int, int>> randomIds = new List<KeyValuePair<int, int>>();

                for (int i = 0; i < 200; i++)
                {
                    var randomStudentIndex = rnd.Next(0, studentsFromDb.Count);
                    var randomStudent = studentsFromDb[randomStudentIndex];

                    var randomCourseIndex = rnd.Next(0, coursessFromDb.Count);
                    var randomCourse = coursessFromDb[randomCourseIndex];

                    var studentInCourse = new StudentCourse
                    {
                        Student = randomStudent,
                        Course = randomCourse
                    };

                    var randomKvp = new KeyValuePair<int, int>(randomStudent.StudentId, randomCourse.CourseId);

                    randomIds.Add(randomKvp);
                }

                randomIds = randomIds.Distinct().ToList();

                foreach (var idPair in randomIds)
                {
                    db.StudentCourses.Add(new StudentCourse
                    {
                        StudentId = idPair.Key,
                        CourseId = idPair.Value
                    });
                }

                Console.WriteLine(db.SaveChanges());
            }
        }

        private static List<Student> GenerateStudents(string[] firstNames, string[] lastNames)
        {
            var students = new List<Student>();

            foreach (var firstName in firstNames)
            {
                foreach (var lastName in lastNames)
                {
                    var name = $"{firstName} {lastName}";
                    var student = new Student
                    {
                        Name = name,
                    };

                    students.Add(student);
                }
            }

            return students;
        }

        private static List<Course> GenerateCourses(string[] courseNames, string[] languages)
        {
            var initialPrice = 0;
            var maxPrice = 600;
            Random rand = new Random(20);

            List<Course> allCourses = new List<Course>();

            foreach (var lang in languages)
            {
                foreach (var module in courseNames)
                {
                    string courseName = $"{lang} {module}";
                    int randPrice = rand.Next(initialPrice, maxPrice);

                    var course = new Course
                    {
                        Name = courseName,
                        Description = $"Description for the {courseName}",
                        Price = randPrice,
                    };

                    allCourses.Add(course);
                }
            }

            return allCourses;
        }

        private static int SeedCourses(List<Course> courses)
        {
            using (var context = new StudentSystemContext())
            {
                context.Courses.AddRange(courses);
                return context.SaveChanges();
            }
        }
        private static int SeedStudents(List<Student> students)
        {
            using (var context = new StudentSystemContext())
            {
                context.Students.AddRange(students);
                return context.SaveChanges();
            }
        }
    }
}
