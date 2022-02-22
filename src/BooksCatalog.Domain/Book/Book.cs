using BooksCatalog.Domain.SeedWork;

namespace BooksCatalog.Domain.Book;

public class Book : AggregateRoot
{
    public Book(string title, int year, string description)
    {
        Title = title;
        Year = year;
        Description = description;
    }
    public void Update(string title, int year, string description)
    {
        Title = title;
        Year = year;
        Description = description;
    }

    public string Title { get; private set; }
    public int Year { get; private set; }
    public string Description { get; private set; }
}
