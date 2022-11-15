using Ef_Core_31.Models;
using Microsoft.EntityFrameworkCore;

namespace Ef_Core_31.MyDbContext
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DatabaseContext()
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<UserBook> UserBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBulder)
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Ef_Core_31;Trusted_Connection=True;";

            if (optionsBulder.IsConfigured == false)
            {

                optionsBulder.UseSqlServer(connectionString);

            }
            base.OnConfiguring(optionsBulder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(q => q.AuthorId);
                entityTypeBuilder.Property(q => q.FirstName).IsRequired().HasMaxLength(50);
                entityTypeBuilder.Property(q => q.LastName).IsRequired().HasMaxLength(50);
                entityTypeBuilder.Property(q => q.Country).IsRequired().HasMaxLength(50);

                entityTypeBuilder
                .HasMany(q=>q.Books)
                .WithOne(q => q.Author)
                .HasForeignKey(q=>q.BookId).IsRequired(); ;

            });

            modelBuilder.Entity<User>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(q => q.UserId);
                entityTypeBuilder.Property(q => q.FirstName).IsRequired().HasMaxLength(50);
                entityTypeBuilder.Property(q => q.LastName).IsRequired().HasMaxLength(50);
                entityTypeBuilder.HasIndex(q => new { q.Email }).IsUnique();

                entityTypeBuilder
                .HasMany(q=>q.UserBooks)
                .WithOne(q=>q.User)
                .HasForeignKey(q=>q.UserId).IsRequired(); ;


            });

            modelBuilder.Entity<Book>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(q => q.BookId);
                entityTypeBuilder.Property(q => q.Name).IsRequired().HasMaxLength(50);

                entityTypeBuilder
                .HasOne(q=>q.Author)
                .WithMany(q=>q.Books)
                .HasForeignKey(q=>q.AuthorId).IsRequired(); ;

                entityTypeBuilder
                .HasMany(q=>q.UserBooks)
                .WithOne(q=>q.Book)
                .HasForeignKey(q=>q.BookId).IsRequired(); ;

              
            });

            modelBuilder.Entity<UserBook>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(q => q.UserBookId);
            });

          
           

        }
    }
}
