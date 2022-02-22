using BooksCatalog.Domain.Book;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra.Persistence;

public class BooksCatalogContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public BooksCatalogContext(DbContextOptions<BooksCatalogContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Book>(eb => eb.HasKey(x => x.Id));
}
