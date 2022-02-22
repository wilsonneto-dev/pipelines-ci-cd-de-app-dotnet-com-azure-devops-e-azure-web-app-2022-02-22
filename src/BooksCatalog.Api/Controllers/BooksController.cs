using BooksCatalog.Domain.Book;
using BooksCatalog.Infra.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace BooksCatalog.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _repository;

    public BooksController(IBookRepository repository) 
        => _repository = repository;

    [HttpGet]
    public async Task<ActionResult> List()
        => Ok(await _repository.List());

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> Get([FromRoute] Guid id)
    {
        var book = await _repository.GetAsync(id);
        if (book is null)
            return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] BookInputModel input)
    {
        var book = new Book(input.Title, input.Year, input.Description);
        await _repository.CreateAsync(book);
        return Created(nameof(Get), new { book.Id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update([FromBody] BookInputModel input, [FromRoute] Guid id)
    {
        var book = await _repository.GetAsync(id);
        if (book is null)
            return NotFound();
        book.Update(input.Title, input.Year, input.Description);
        await _repository.UpdateAsync(book);
        return NoContent();
    }
}

public class BookInputModel
{
    public BookInputModel(string title, int year, string description)
    {
        Title = title;
        Year = year;
        Description = description;
    }

    public string Title { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
}