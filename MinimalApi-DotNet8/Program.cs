using Microsoft.EntityFrameworkCore;
using MinimalApi_DotNet8.Data;
using MinimalApi_DotNet8.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add db context
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//create app.get endpoint to return all books from db context
app.MapGet("/books", async (DataContext context) =>
{
    var books = await context.Books.ToListAsync();
    if (books is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(books);
});

//create app.get endpoint to return a single book from db context
app.MapGet("/books/{id}", async (DataContext context, int id) =>
{
    var book = await context.Books.FindAsync(id);
    if (book is null)
    {
        return Results.NotFound("Book is missing :)");
    }
    return Results.Ok(book);
});

//create app.post endpoint to add a book to db context
app.MapPost("/books", async (DataContext context, Book book) =>
{
    await context.Books.AddAsync(book);
    await context.SaveChangesAsync();
    return Results.Created($"/books/{book.Id}", book);
});

//create app.put endpoint to update a book in db context
app.MapPut("/books/{id}", async (DataContext context, int id, Book book) =>
{
    if (id != book.Id)
    {
        return Results.BadRequest("Book Id mismatch");
    }
    context.Books.Update(book);
    await context.SaveChangesAsync();
    return Results.Ok(book);
});

app.MapDelete("/books/{id}", async (DataContext context, int id) =>
{
    var book = await context.Books.FindAsync(id);
    if (book is null)
    {
        return Results.NotFound("Book is missing :)");
    }
    context.Books.Remove(book);
    await context.SaveChangesAsync();
    return Results.Ok();
});


app.Run();
