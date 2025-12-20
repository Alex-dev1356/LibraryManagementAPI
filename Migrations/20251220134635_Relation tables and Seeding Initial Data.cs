using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class RelationtablesandSeedingInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "An American novelist and short story writer.", "F. Scott Fitzgerald" },
                    { 2, "An American novelist widely known for To Kill a Mockingbird.", "Harper Lee" },
                    { 3, "An English novelist, essayist, journalist and critic.", "George Orwell" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AuthorID", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1925, "The Great Gatsby" },
                    { 2, 2, 1960, "To Kill a Mockingbird" },
                    { 3, 3, 1949, "1984" },
                    { 4, 1, 1813, "Pride and Prejudice" },
                    { 5, 2, 1951, "The Catcher in the Rye" },
                    { 6, 3, 1925, "The Great Gatsby" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
