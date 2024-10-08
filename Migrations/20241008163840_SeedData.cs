using Microsoft.EntityFrameworkCore.Migrations;
using static demo_odata.Models.Enums;

#nullable disable

namespace demo_odata.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: ["Id", "City", "Street"],
                values: new object[,]
                {
                    { 1, "New York", "5th Avenue" },
                    { 2, "Los Angeles", "Sunset Boulevard" }
                });

            migrationBuilder.InsertData(
                table: "Presses",
                columns: ["Id", "Name", "Email", "Category"],
                values: new object[,]
                {
                    { 1, "Random House", "info@randomhouse.com", (int)Category.Book },
                    { 2, "Time Inc.", "contact@timeinc.com", (int)Category.Magazine }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: ["Id", "ISBN", "Title", "Author", "Price", "LocationId", "PressId"],
                values: new object[,]
                {
                    { 1, "978-3-16-148410-0", "Sample Book", "John Doe", 29.99m, 1, 1 },
                    { 2, "978-1-23-456789-0", "Another Book", "Jane Smith", 19.99m, 2, 2 },
                    { 3, "978-0-11-111111-1", "New Release", "Alice Johnson", 24.99m, 1, 2 },
                    { 4, "978-0-22-222222-2", "Fiction Story", "Bob Brown", 14.99m, 2, 1 },
                    { 5, "978-0-33-333333-3", "Tech Guide", "Carol White", 39.99m, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                        table: "Books",
                        keyColumn: "Id",
                        keyValues: [1, 2]);

            migrationBuilder.DeleteData(
                table: "Presses",
                keyColumn: "Id",
                keyValues: [1, 2]);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValues: [1, 2]);
        }
    }
}
