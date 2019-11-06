namespace StudentSystem.Data
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Microsoft.Extensions.Logging;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging.Console;

    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext()
        {
        }
        public StudentSystemDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        //public DbSet<Resource> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            LoggerFactory SqlCommandLoggerFactory = new
                LoggerFactory(new[]
                {
                    new ConsoleLoggerProvider((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information, true)
                });

            optionsBuilder
                    .UseSqlServer("Server=.\\SQLEXPRESS;Database=StudentSystem;Integrated Security=True", s => s.MigrationsAssembly("StudentSystem.Data"))
                    .UseLoggerFactory(SqlCommandLoggerFactory)
                    .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity
                    .HasKey(s => s.StudentId);

                entity
                    .OwnsOne(s => s.Name);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity
                    .HasData(new Course[]
                    {
                        new Course()
                        {
                            CourseId = 1,
                            Name = "EF Framework",
                            Description = "Testing",
                            StartDate = new DateTime(2019, 1, 20),
                            EndDate = new DateTime(2019, 3, 30)
                        }
                    });
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity
                    .HasData(new Resource[]
                    {
                        new Resource()
                        {
                            ResourceId = 1,
                            CourseId = 1,
                            Name = "Presentation",
                            Type = ResourceType.Presentation,
                            Url = "www.studentsystem.my/presentation"
                        }
                    });
            });

            modelBuilder.Entity<StudentCourses>(entity =>
            {
                entity
                    .HasKey(sc => new { sc.StudentId, sc.CourseId});
            });
        }
    }
}
