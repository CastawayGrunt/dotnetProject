using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnetProject.Migrations
{
    /// <inheritdoc />
    public partial class Orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1b81a292-901f-42a3-b142-1ee1420292bc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2750094b-5162-47fa-8929-d02a0568d208"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("37e7e501-e02e-4d41-8b2f-d5319bfc4e7a"));

            migrationBuilder.CreateTable(
                name: "AddressModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Province = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Products = table.Column<List<Guid>>(type: "uuid[]", nullable: false),
                    ShippingAddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderPlacedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OrderTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderStatus = table.Column<int>(type: "integer", nullable: false),
                    OrderNumber = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AddressModel_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "AddressModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Sold", "Stock" },
                values: new object[,]
                {
                    { new Guid("18fcd916-f8e4-4ca0-a017-c8832407f38c"), "Product 3 Description", "https://via.placeholder.com/150", "Product 3", 30.00m, 0, 30 },
                    { new Guid("6a0f8d7c-22e7-4453-ad8a-091b54516654"), "Product 1 Description", "https://via.placeholder.com/150", "Product 1", 10.00m, 0, 10 },
                    { new Guid("e8503b9b-1328-4aff-9fcd-67e2a0aab429"), "Product 2 Description", "https://via.placeholder.com/150", "Product 2", 20.00m, 0, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AddressModel");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("18fcd916-f8e4-4ca0-a017-c8832407f38c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6a0f8d7c-22e7-4453-ad8a-091b54516654"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e8503b9b-1328-4aff-9fcd-67e2a0aab429"));

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
    }
}
