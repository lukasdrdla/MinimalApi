﻿namespace MinimalApi_DotNet8.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Genre { get; set; }
        public int? Year { get; set; }

    }
}
