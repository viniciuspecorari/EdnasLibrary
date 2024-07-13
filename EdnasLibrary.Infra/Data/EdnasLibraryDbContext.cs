using EdnasLibrary.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EdnasLibrary.Infra.Data
{
    public class EdnasLibraryDbContext : IdentityDbContext<User>
    {
        public EdnasLibraryDbContext(DbContextOptions<EdnasLibraryDbContext> options) : base(options)
        {
            
        }

        DbSet<Book> Books { get; set; }
        DbSet<BooksLoan> BooksLoans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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
