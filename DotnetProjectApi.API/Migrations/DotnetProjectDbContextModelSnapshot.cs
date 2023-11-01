﻿// <auto-generated />
using System;
using DotnetProjectApi.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace dotnetProject.Migrations
{
    [DbContext(typeof(DotnetProjectDbContext))]
    partial class DotnetProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DotnetProjectApi.API.Features.Orders.Models.AddressModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AddressModel");
                });

            modelBuilder.Entity("DotnetProjectApi.API.Features.Orders.Models.OrderModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderNumber")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("OrderPlacedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("integer");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ShippingAddressId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShippingAddressId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DotnetProjectApi.API.Features.Orders.OrderDetailModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("OrderModelId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderModelId");

                    b.ToTable("OrderDetailModel");
                });

            modelBuilder.Entity("DotnetProjectApi.API.Features.Products.Models.ProductModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Sold")
                        .HasColumnType("integer");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("009ba35e-e745-4e6b-84d5-16a92c9bfe8e"),
                            Description = "Product 1 Description",
                            ImageUrl = "https://via.placeholder.com/150",
                            Name = "Product 1",
                            Price = 10.00m,
                            Sold = 0,
                            Stock = 10
                        },
                        new
                        {
                            Id = new Guid("c7565bec-e61c-4dbc-a291-c18a1d4ee70d"),
                            Description = "Product 2 Description",
                            ImageUrl = "https://via.placeholder.com/150",
                            Name = "Product 2",
                            Price = 20.00m,
                            Sold = 0,
                            Stock = 20
                        },
                        new
                        {
                            Id = new Guid("085f8264-ea9a-4419-8bd3-6c07808080f8"),
                            Description = "Product 3 Description",
                            ImageUrl = "https://via.placeholder.com/150",
                            Name = "Product 3",
                            Price = 30.00m,
                            Sold = 0,
                            Stock = 30
                        });
                });

            modelBuilder.Entity("DotnetProjectApi.API.Features.Orders.Models.OrderModel", b =>
                {
                    b.HasOne("DotnetProjectApi.API.Features.Orders.Models.AddressModel", "ShippingAddress")
                        .WithMany()
                        .HasForeignKey("ShippingAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShippingAddress");
                });

            modelBuilder.Entity("DotnetProjectApi.API.Features.Orders.OrderDetailModel", b =>
                {
                    b.HasOne("DotnetProjectApi.API.Features.Orders.Models.OrderModel", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderModelId");
                });

            modelBuilder.Entity("DotnetProjectApi.API.Features.Orders.Models.OrderModel", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
