using FuncBooksStore.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuncBooksStore.Persistence;

public class BooksDbContext(DbContextOptions<BooksDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Specify the SQL Server column type for the 'Pages' property
        modelBuilder.Entity<Book>()
            .Property(b => b.Pages)
            .HasColumnType("decimal(18,0)"); // Adjust precision and scale as needed

        base.OnModelCreating(modelBuilder);
    }
}
