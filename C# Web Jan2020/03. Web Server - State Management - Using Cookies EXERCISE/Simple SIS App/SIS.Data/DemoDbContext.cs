namespace SIS.Data
{
    using SIS.Models;

    using Microsoft.EntityFrameworkCore;

    public class DemoDbContext : DbContext
    {
        public DemoDbContext()
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=BODYQUEST-THINK\SQLEXPRESS;Database=SISDb;Integrated Security=True;Trusted_Connection=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);
        }
    }
}
