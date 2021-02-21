// <copyright file="AppDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "Server=127.0.0.1;Port=3306;Database=OnlineShop;Uid=root;Pwd=root;",
                new MySqlServerVersion(new Version(8, 0, 22)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel
                {
                    ProductId = 1,
                    Category = "TShirt",
                    Price = 20,
                    Count = 10,
                    Description = "Rand Desc"
                }) ;
        }

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<ReviewModel> Reviews { get; set; }

        public DbSet<AccountModel> Accounts { get; set; }
    }
}
