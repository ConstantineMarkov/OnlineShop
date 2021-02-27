﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Models;

namespace OnlineShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("OnlineShop.Models.AccountModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("LastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("PhoneNumber");

                    b.Property<bool>("Type")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("Type");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("OnlineShop.Models.BuyingHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("FKOrdersId")
                        .HasColumnType("int");

                    b.Property<int>("FKUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FKOrdersId");

                    b.HasIndex("FKUserId");

                    b.ToTable("BuyingHistory");
                });

            modelBuilder.Entity("OnlineShop.Models.OrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("Count");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Date");

                    b.Property<int>("OrdersProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrdersProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Models.ProductModel", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Category");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("Count");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("Price");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OnlineShop.Models.ReviewModel", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("FKAccountId")
                        .HasColumnType("int");

                    b.Property<int>("ProductModel")
                        .HasColumnType("int");

                    b.Property<int>("StarCount")
                        .HasColumnType("int")
                        .HasColumnName("StarCount");

                    b.Property<string>("TextReview")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("TextReview");

                    b.HasKey("ReviewId");

                    b.HasIndex("FKAccountId");

                    b.HasIndex("ProductModel");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("OnlineShop.Models.BuyingHistory", b =>
                {
                    b.HasOne("OnlineShop.Models.OrderModel", "OrderId")
                        .WithMany()
                        .HasForeignKey("FKOrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Models.AccountModel", "AccountId")
                        .WithMany()
                        .HasForeignKey("FKUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountId");

                    b.Navigation("OrderId");
                });

            modelBuilder.Entity("OnlineShop.Models.OrderModel", b =>
                {
                    b.HasOne("OnlineShop.Models.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("OrdersProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Models.ReviewModel", b =>
                {
                    b.HasOne("OnlineShop.Models.AccountModel", "Account")
                        .WithMany()
                        .HasForeignKey("FKAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Models.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductModel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
