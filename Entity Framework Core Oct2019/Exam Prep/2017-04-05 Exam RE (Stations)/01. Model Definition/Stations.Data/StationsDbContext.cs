namespace Stations.Data
{
    using Microsoft.EntityFrameworkCore;
    using Stations.Models;

    public class StationsDbContext : DbContext
	{
		public StationsDbContext()
		{
		}

		public StationsDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Station> Stations { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<SeatingClass> SeatingClasses { get; set; }
        public DbSet<TrainSeat> TrainSeats { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<CustomerCard> CustomerCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Station>().HasAlternateKey(s => s.Name);
            modelBuilder.Entity<Train>().HasAlternateKey(t => t.TrainNumber);
            modelBuilder.Entity<SeatingClass>().HasAlternateKey(sc => new { sc.Name, sc.Abbreviation });

            modelBuilder.Entity<Station>()
                .HasMany(s => s.TripsTo)
                .WithOne(t => t.DestinationStation)
                .HasForeignKey(s => s.DestinationStationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Station>()
                .HasMany(s => s.TripsFrom)
                .WithOne(t => t.OriginStation)
                .HasForeignKey(s => s.OriginStationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
	}
}