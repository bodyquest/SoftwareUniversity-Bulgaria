namespace BookShop.Data
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookShopContext : DbContext
    {
        public BookShopContext()
        {
        }

        public BookShopContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BooksCategories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey( e => e.AuthorId);

                entity
                    .Property(e => e.FirstName)
                    .HasColumnType("NVARCHAR(50)")
                    .IsRequired(false);

                entity
                    .Property(e => e.LastName)
                    .HasColumnType("NVARCHAR(50)")
                    .IsRequired(true);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity
                    .Property(e => e.Title)
                    .HasColumnType("NVARCHAR(50)")
                    .IsRequired(true);

                entity
                    .Property(e => e.Description)
                    .HasColumnType("NVARCHAR(1000)")
                    .IsRequired(true);

                entity
                    .Property(e => e.ReleaseDate)
                    .HasColumnType("DATETIME2")
                    .IsRequired(false);

                entity
                    .HasOne(e => e.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(e => e.AuthorId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.Name).HasColumnType("NVARCHAR(50)").IsRequired(true);
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.HasKey(e => new {e.BookId, e.CategoryId });

                entity
                    .HasOne(e => e.Book)
                    .WithMany(bc => bc.BookCategories)
                    .HasForeignKey(e => e.BookId);

                entity
                    .HasOne(e => e.Category)
                    .WithMany(bc => bc.CategoryBooks)
                    .HasForeignKey(e => e.CategoryId);
            });
        }
    }
}
