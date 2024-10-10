using Books.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options)
        : base(options)
    {
    }
    public DbSet<BookEntity> Books { get; set; }
}