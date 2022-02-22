using BooksCatalog.Domain.Book;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BooksCatalogContext _context;
    private DbSet<Book> _books => _context.Books;

    public BookRepository(BooksCatalogContext context) => _context = context;


    public async Task CreateAsync(Book aggregate)
    {
        await _books.AddAsync(aggregate);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Book aggregate)
    {
        _books.Remove(aggregate);
        await _context.SaveChangesAsync();
    }

    public async Task<Book?> GetAsync(Guid id)
        => await _books.FindAsync(id);

    public async Task<IList<Book>> List() 
        => await _books.OrderBy(x => x.Title).ToListAsync();
    
    public async Task UpdateAsync(Book aggregate)
    {
        _books.Update(aggregate);
        await _context.SaveChangesAsync();
    }
}
