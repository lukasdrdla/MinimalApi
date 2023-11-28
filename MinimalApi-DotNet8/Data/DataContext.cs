using Microsoft.EntityFrameworkCore;
using MinimalApi_DotNet8.Models;

namespace MinimalApi_DotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //create OnModelCreating method to seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Fiction", Year = 1925 },
                new Book { Id = 2, Title = "The Grapes of Wrath", Author = "John Steinbeck", Genre = "Fiction", Year = 1939 },
                new Book { Id = 3, Title = "Nineteen Eighty-Four", Author = "George Orwell", Genre = "Fiction", Year = 1949 },
                new Book { Id = 4, Title = "Ulysses", Author = "James Joyce", Genre = "Fiction", Year = 1922 },
                new Book { Id = 5, Title = "Lolita", Author = "Vladimir Nabokov", Genre = "Fiction", Year = 1955 },
                new Book { Id = 6, Title = "Catch-22", Author = "Joseph Heller", Genre = "Fiction", Year = 1961 },
                new Book { Id = 7, Title = "The Catcher in the Rye", Author = "J. D. Salinger", Genre = "Fiction", Year = 1951 },
                new Book { Id = 8, Title = "Beloved", Author = "Toni Morrison", Genre = "Fiction", Year = 1987 },
                new Book { Id = 9, Title = "The Sound and the Fury", Author = "William Faulkner", Genre = "Fiction", Year = 1929 },
                new Book { Id = 10, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", Year = 1960 });
        }

        public DbSet<Book> Books { get; set; } = null!;
    }
}
