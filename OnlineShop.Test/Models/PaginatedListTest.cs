using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Test.Models
{
    public class PaginatedListTest
    {
        OnlineShopContext context; 

        [SetUp]
        public void SetUp()
        {
            var opt = new DbContextOptionsBuilder<OnlineShopContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            context = new OnlineShopContext(opt);

        }

        //[TearDown]
        //public void 

        //[Test]
        //public void TestConstructorInit()
        //{
        //    List <ProductModel> pm = context.Products.ToList();

        //    items = new Mock<context>
        //}
    }
}
