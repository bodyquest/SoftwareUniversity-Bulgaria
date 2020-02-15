namespace MishMash.Data
{
    using Microsoft.EntityFrameworkCore;
    using MishMash.Domain;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ChannelTag> ChannelTags { get; set; }
        public DbSet<UserChannel> UserChannels { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
