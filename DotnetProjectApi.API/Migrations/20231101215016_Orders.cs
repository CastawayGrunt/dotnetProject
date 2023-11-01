using System;
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

            migrationBuilder.CreateTable(
                name: "OrderDetailModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetailModel_Orders_OrderModelId",
                        column: x => x.OrderModelId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Sold", "Stock" },
                values: new object[,]
                {
                    { new Guid("009ba35e-e745-4e6b-84d5-16a92c9bfe8e"), "Product 1 Description", "https://via.placeholder.com/150", "Product 1", 10.00m, 0, 10 },
                    { new Guid("085f8264-ea9a-4419-8bd3-6c07808080f8"), "Product 3 Description", "https://via.placeholder.com/150", "Product 3", 30.00m, 0, 30 },
                    { new Guid("c7565bec-e61c-4dbc-a291-c18a1d4ee70d"), "Product 2 Description", "https://via.placeholder.com/150", "Product 2", 20.00m, 0, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailModel_OrderModelId",
                table: "OrderDetailModel",
                column: "OrderModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetailModel");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AddressModel");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("009ba35e-e745-4e6b-84d5-16a92c9bfe8e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("085f8264-ea9a-4419-8bd3-6c07808080f8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c7565bec-e61c-4dbc-a291-c18a1d4ee70d"));

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
