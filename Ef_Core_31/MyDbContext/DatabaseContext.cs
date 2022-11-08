using Ef_Core_31.Models;
using Microsoft.EntityFrameworkCore;

namespace Ef_Core_31.MyDbContext
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DatabaseContext()
        {

        }

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Users> Users { get; set; }

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

            modelBuilder.Entity<Authors>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(q => q.AuthorId);
                entityTypeBuilder.Property(q => q.FirstName).IsRequired().HasMaxLength(50);
                entityTypeBuilder.Property(q => q.LastName).IsRequired().HasMaxLength(50);
                entityTypeBuilder.Property(q => q.Country).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(q => q.UserId);
                entityTypeBuilder.Property(q => q.FirstName).IsRequired().HasMaxLength(50);
                entityTypeBuilder.Property(q => q.LastName).IsRequired().HasMaxLength(50);
                entityTypeBuilder.HasIndex(q => new { q.Email }).IsUnique();
            });

            modelBuilder.Entity<Books>(entityTypeBuilder =>
            {

                

            });

        }
    }
}
