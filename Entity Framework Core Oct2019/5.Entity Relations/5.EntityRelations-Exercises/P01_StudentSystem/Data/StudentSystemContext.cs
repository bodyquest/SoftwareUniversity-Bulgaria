namespace P01_StudentSystem.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }
        public StudentSystemContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataSettings.DefaultConection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
                entity.HasKey(e => e.StudentId);
                entity.Property(e => e.Name).HasMaxLength(100).IsUnicode(true).IsRequired(true);
                entity.Property(e => e.PhoneNumber).IsRequired(false).IsUnicode(false).HasColumnType("CHAR(10)");
                entity.Property(e => e.RegisteredOn).IsRequired(true);
                entity.Property(e => e.Birthday).IsRequired(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Courses");
                entity.HasKey(e => e.CourseId);
                entity.Property(e => e.Name).HasMaxLength(100).IsUnicode(true).IsRequired(true);
                entity.Property(e => e.Description).IsUnicode(true).IsRequired(false);
                entity.Property(e => e.StartDate).IsRequired(true);
                entity.Property(e => e.EndDate).IsRequired(true);
                entity.Property(e => e.Price).IsRequired(true);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("Resources");
                entity.HasKey(e => e.ResourceId);
                entity.Property(e => e.Name).HasMaxLength(50).IsUnicode(true).IsRequired(true);
                entity.Property(e => e.Url).IsRequired(true).IsUnicode(false);
                entity.Property(e => e.ResourceType).IsRequired(true);

                entity.HasOne(c => c.Course).WithMany(r => r.Resources)
                .HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.ToTable("HomeworkSubmissions");
                entity.HasKey(e => e.HomeworkId);
                entity.Property(e => e.Content).IsRequired(true).IsUnicode(false);
                entity.Property(e => e.ContentType).IsRequired(true);
                entity.Property(e => e.SubmissionTime).IsRequired(true);

                entity.HasOne(s => s.Student).WithMany(h => h.HomeworkSubmissions)
                .HasForeignKey(s => s.StudentId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Course).WithMany(h => h.HomeworkSubmissions)
                .HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.ToTable("StudentCourses");
                entity.HasKey(e => new { e.StudentId, e.CourseId });

                entity.HasOne(s => s.Course).WithMany(c => c.StudentsEnrolled)
                .HasForeignKey(s => s.StudentId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Student).WithMany(s => s.CourseEnrollments)
                .HasForeignKey(c => c.StudentId).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
