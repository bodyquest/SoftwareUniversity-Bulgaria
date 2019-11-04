namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataSettings.DefaultConection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.OnModelCreatingDoctor(modelBuilder);
            this.OnModelCreatingDoctor(modelBuilder);
            this.OnModelCreatingDiagnose(modelBuilder);
            this.OnModelCreatingVisitation(modelBuilder);
            this.OnModelCreatingMedicament(modelBuilder);
            this.OnModelCreatingPatientMedicament(modelBuilder);
        }

        private void OnModelCreatingDoctor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(d => d.DoctorId);

                entity
                    .HasMany(d => d.Visitations)
                    .WithOne(v => v.Doctor);

                entity
                    .Property(d => d.Name)
                    .HasMaxLength(100)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                     .Property(d => d.Specialty)
                     .HasMaxLength(100)
                     .IsRequired(true)
                     .IsUnicode(true);
            });
        }

        private void OnModelCreatingDiagnose(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(d => d.DiagnoseId);

                entity
                    .Property(d => d.Name)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(d => d.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity
                    .HasOne(p => p.Patient)
                    .WithMany(d => d.Diagnoses)
                    .HasForeignKey(k => k.PatientId);
            });
        }

        private void OnModelCreatingVisitation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.HasKey(v => v.VisitationId);

                entity
                    .Property(v => v.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(true);

                entity
                    .HasOne(p => p.Patient)
                    .WithMany(v => v.Visitations)
                    .HasForeignKey(k => k.PatientId);
            });
        }

        private void OnModelCreatingMedicament(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(m => m.MedicamentId);

                entity
                    .Property(m => m.Name)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .HasMany(p => p.Prescriptions)
                    .WithOne(m => m.Medicament)
                    .HasForeignKey(k => k.MedicamentId);
            });
        }

        private void OnModelCreatingPatientMedicament(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pm => new { pm.PatientId, pm.MedicamentId });

                entity
                 .HasOne(pm => pm.Patient)
                 .WithMany(p => p.Prescriptions)
                 .HasForeignKey(pm => pm.PatientId);

                entity
                 .HasOne(pm => pm.Medicament)
                 .WithMany(m => m.Prescriptions)
                 .HasForeignKey(pm => pm.MedicamentId);
            });
        }
    }
}
