using BooksCatalog.Domain.Book;
using BooksCatalog.Infra.Persistence;
using BooksCatalog.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddDbContext<BooksCatalogContext>(options =>
    // options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"))
    options.UseInMemoryDatabase("db")
); ;

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
