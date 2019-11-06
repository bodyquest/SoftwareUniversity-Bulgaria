namespace StudentSystem
{
    using System;
    using System.Linq;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using StudentSystem.Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new StudentSystemDbContext())
            {
                //context.Database.EnsureCreated();
                //SeedStudents(context);
                var student = context.Students
                    .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                    .FirstOrDefault();
                //var course = context.Courses.FirstOrDefault();

                //student.StudentCourses.Add(new StudentCourses()
                //{
                //    Course = course
                //});

                //context.SaveChanges();

                //context.Database.Migrate(); 
            }
        }
        private static void SeedStudents(StudentSystemDbContext context)
        {
            if (context.Students.Count() == 0)
            {
                var students = new Student[]
                 {
                     new Student()
                {
                    Name = new PersonName ("Ivan", "Petrov"),
                    Birthday = new DateTime(1989, 5, 24),
                    PhoneNumber = "8948586872",
                    RegisteredOn = DateTime.Now
                },

                     new Student()
                {
                    Name = new PersonName ("Petar", "Ivanov"),
                    Birthday = new DateTime(1990, 6, 18),
                    PhoneNumber = "08948586811",
                    RegisteredOn = DateTime.Now
                },

                     new Student()
                {
                    Name = new PersonName ("Chocho", "Chochev"),
                    Birthday = new DateTime(1986, 12, 25),
                    PhoneNumber = "08858586900",
                    RegisteredOn = DateTime.Now
                }
                 };

                context.Students.AddRange(students);
                context.SaveChanges();
            }
        }
    }
}
