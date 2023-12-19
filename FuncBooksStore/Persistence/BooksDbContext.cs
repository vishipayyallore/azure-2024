using FuncBooksStore.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuncBooksStore.Persistence;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}
