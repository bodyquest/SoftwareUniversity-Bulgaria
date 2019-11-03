namespace P03_SalesDatabase.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataSettings.DefaultConection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.OnModelCreatingProduct(modelBuilder);
            this.OnModelCreatingCustomer(modelBuilder);
            this.OnModelCreatingStore(modelBuilder);
            this.OnModelCreatingSale(modelBuilder);
        }

        private void OnModelCreatingProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);

                entity
                    .Property(p => p.Name)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(p => p.Quantity)
                    .IsRequired(true);

                entity
                    .Property(p => p.Price)
                    .IsRequired(true);

                entity
                    .Property(p => p.Description)
                    .HasMaxLength(250);
            });
        }

        private void OnModelCreatingCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity
                    .HasKey(c => c.CustomerId);

                entity
                    .Property(c => c.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity
                    .Property(c => c.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity
                    .Property(c => c.CreditCardNumber)
                    .HasMaxLength(16)
                    .IsRequired(true)
                    .IsUnicode(false);
            });
        }

        private void OnModelCreatingStore(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>(entity =>
            {
                entity
                    .HasKey(s => s.StoreId);

                entity
                    .Property(s => s.Name)
                    .HasMaxLength(80)
                    .IsRequired(true)
                    .IsUnicode(true);
            });
        }

        private void OnModelCreatingSale(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>(entity =>
            {
                entity
                    .HasKey(s => s.SaleId);

                entity
                    .Property(s => s.Date)
                    .IsRequired(true)
                    .HasColumnType("DATETIME2")
                    .HasDefaultValueSql("GETDATE()");

                entity
                    .HasOne(s => s.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(s => s.ProductId);

                entity
                    .HasOne(s => s.Customer)
                    .WithMany(c => c.Sales)
                    .HasForeignKey(s => s.CustomerId);

                entity
                    .HasOne(s => s.Store)
                    .WithMany(st => st.Sales)
                    .HasForeignKey(s => s.StoreId);
            });
        }
    }
}

