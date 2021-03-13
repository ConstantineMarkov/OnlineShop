using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public class OnlineShopContext : IdentityDbContext<OnlineShopUser>
    {
        public OnlineShopContext()
        {
        }

        private IHttpContextAccessor _contextAccessor;

        public OnlineShopContext(DbContextOptions<OnlineShopContext> options, IHttpContextAccessor contextAccessor)
            : base(options)
        {
            _contextAccessor = contextAccessor;
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

        public DbSet<CategoryModel> CategoryModel { get; set; }

        public DbSet<OnlineShopUser> OnlineShopUsers { get; set; }

        public DbSet<CartModel> CartModel { get; set; }
    }
}
