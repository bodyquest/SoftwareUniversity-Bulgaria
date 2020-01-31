using Microsoft.EntityFrameworkCore;
using Panda.Models;

namespace Panda.Data
{
    public class PandaAppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>()
            .HasOne(i => i.Recipient)
            .WithMany(c => c.Packages)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
