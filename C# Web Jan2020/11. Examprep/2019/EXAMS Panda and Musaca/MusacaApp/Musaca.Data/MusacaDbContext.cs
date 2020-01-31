namespace Musaca.Data
{
    using Musaca.Models;

    using Microsoft.EntityFrameworkCore;

    public class MusacaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrdersProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Order>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Order>()
            .HasOne(x => x.Cashier);

            modelBuilder.Entity<Order>()
            .HasMany(order => order.Products)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<OrderProduct>()
            .HasKey(orderProduct => new { orderProduct.OrderId, orderProduct.ProductId});

            base.OnModelCreating(modelBuilder);
        }
    }
}
