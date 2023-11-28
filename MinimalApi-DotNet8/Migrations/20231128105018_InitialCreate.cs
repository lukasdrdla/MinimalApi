using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalApi_DotNet8.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genre", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", "Fiction", "The Great Gatsby", 1925 },
                    { 2, "John Steinbeck", "Fiction", "The Grapes of Wrath", 1939 },
                    { 3, "George Orwell", "Fiction", "Nineteen Eighty-Four", 1949 },
                    { 4, "James Joyce", "Fiction", "Ulysses", 1922 },
                    { 5, "Vladimir Nabokov", "Fiction", "Lolita", 1955 },
                    { 6, "Joseph Heller", "Fiction", "Catch-22", 1961 },
                    { 7, "J. D. Salinger", "Fiction", "The Catcher in the Rye", 1951 },
                    { 8, "Toni Morrison", "Fiction", "Beloved", 1987 },
                    { 9, "William Faulkner", "Fiction", "The Sound and the Fury", 1929 },
                    { 10, "Harper Lee", "Fiction", "To Kill a Mockingbird", 1960 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
