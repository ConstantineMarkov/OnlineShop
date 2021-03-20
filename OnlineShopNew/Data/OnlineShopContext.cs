using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.EntityFrameworkCore;

namespace OnlineShop.Data
{
    public class OnlineShopContext : IdentityDbContext<OnlineShopUser>
    {
        public OnlineShopContext(DbContextOptions<OnlineShopContext> options)
            : base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; }

        //public DbSet<ReviewModel> Reviews { get; set; }

        public DbSet<OrderModel> Orders { get; set; }

        public DbSet<BuyingHistory> BuyingHistory { get; set; }

        public DbSet<CategoryModel> CategoryModel { get; set; }

        public DbSet<OnlineShopUser> OnlineShopUsers { get; set; }

        public DbSet<CartModel> CartModel { get; set; }
    }
}
