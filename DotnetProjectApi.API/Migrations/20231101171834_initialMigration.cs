using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnetProject.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    Sold = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Sold", "Stock" },
                values: new object[,]
                {
                    { new Guid("1b81a292-901f-42a3-b142-1ee1420292bc"), "Product 1 Description", "https://via.placeholder.com/150", "Product 1", 10.00m, 0, 10 },
                    { new Guid("2750094b-5162-47fa-8929-d02a0568d208"), "Product 3 Description", "https://via.placeholder.com/150", "Product 3", 30.00m, 0, 30 },
                    { new Guid("37e7e501-e02e-4d41-8b2f-d5319bfc4e7a"), "Product 2 Description", "https://via.placeholder.com/150", "Product 2", 20.00m, 0, 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
