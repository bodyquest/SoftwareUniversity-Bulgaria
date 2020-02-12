namespace MishMashWebPREP.Data
{
    using Microsoft.EntityFrameworkCore;
    using MishMashWebPREP.Models;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserChannel> UserChannel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChannelTag>()
                .HasKey(x => new {x.ChannelId, x.TagId });

            modelBuilder.Entity<UserChannel>()
                .HasKey(x => new { x.ChannelId, x.UserId });
        }
    }
}
