namespace PetClinic.Data
{
    using PetClinic.Models;
    using Microsoft.EntityFrameworkCore;
    using PetClinic.Data.EntityConfiguration;

    public class PetClinicContext : DbContext
    {
        public PetClinicContext() { }

        public PetClinicContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<AnimalAid> AnimalAids { get; set; }
        public DbSet<ProcedureAnimalAid> ProceduresAnimalAids { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProcedureAnimalAid>()
                 .HasKey(x => new { x.ProcedureId, x.AnimalAidId });

            builder.Entity<Vet>()
                .HasIndex(v => v.PhoneNumber).IsUnique();
        }
    }
}
