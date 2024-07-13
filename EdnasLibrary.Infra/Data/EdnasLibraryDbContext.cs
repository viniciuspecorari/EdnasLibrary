using EdnasLibrary.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EdnasLibrary.Infra.Data
{
    public class EdnasLibraryDbContext : DbContext
    {
        public EdnasLibraryDbContext(DbContextOptions<EdnasLibraryDbContext> options) : base(options)
        {
            
        }

        public DbSet<ApiUser> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BooksLoan> BooksLoans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ApiUser>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Entity<ApiUser>()
                .HasIndex(u => u.Email)
                .IsUnique();


            builder.Entity<Book>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Entity<BooksLoan>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");
                       
            base.OnModelCreating(builder);
        }
    }
}
