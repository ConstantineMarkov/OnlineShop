using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Areas.Identity.Data;
using OnlineShop.Models;

namespace OnlineShop.Data
{
    public class OnlineShopContext : IdentityDbContext<OnlineShopUser>
    {
        public OnlineShopContext()
        {
        }
        public OnlineShopContext(DbContextOptions<OnlineShopContext> options)
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
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<ReviewModel> Reviews { get; set; }

        public DbSet<OrderModel> Orders { get; set; }

        public DbSet<BuyingHistory> BuyingHistory { get; set; }

        public DbSet<OnlineShopUser> Accounts { get; set; }

        public DbSet<CategoryModel> CategoryModel { get; set; }
    }
}
