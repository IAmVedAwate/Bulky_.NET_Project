using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyBook.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price1 = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price1", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Billy Spark", "King is time, time is everything, you are bound to time, and time is eternal. Nothing else is true!", "SWD00785", 99.0, 90.0, 80.0, 85.0, "Fortune Of Time" },
                    { 2, "Maya Rivers", "In a world where choices echo through time, three lives intertwine, revealing their shared destiny.", "EOD12345", 120.0, 110.0, 100.0, 105.0, "Echoes of Destiny" },
                    { 3, "Olivia Gray", "Amidst fog-shrouded secrets, a forbidden love blooms, threatening to unravel the town's hidden past.", "WIM67890", 80.0, 75.0, 65.0, 70.0, "Whispers in the Mist" },
                    { 4, "Sebastian Stone", "Alchemy, betrayal, and ancient prophecies collide as an unlikely hero seeks the philosopher's stone.", "TAL45678", 105.0, 95.0, 85.0, 90.0, "The Alchemist's Legacy" },
                    { 5, "Isabella Sands", "Lost artifacts, hidden maps, and a quest for serendipity lead a group of adventurers across deserts and time.", "SOS23456", 70.0, 65.0, 55.0, 60.0, "Sands of Serendipity" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
