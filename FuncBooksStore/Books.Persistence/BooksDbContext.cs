using Books.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.Persistence;

public class BooksDbContext(DbContextOptions<BooksDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();
}
