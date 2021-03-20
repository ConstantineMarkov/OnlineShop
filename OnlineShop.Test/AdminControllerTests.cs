using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using OnlineShop.Controllers;
using OnlineShop.Data;
using Microsoft.EntityFrameworkCore.InMemory;
using System;

namespace OnlineShop.Test
{
    [TestFixture]
    public class Tests
    {
        private OnlineShopContext ctxt;

        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<OnlineShopContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            this.ctxt = new OnlineShopContext(opt);
        }

        [TearDown]
        public void TearDown()
        {
            this.ctxt.Database.EnsureDeleted();
        }

        [Test]
        public void Index()
        {
            AdminController ac = new AdminController(ctxt);

            ctxt.Products.Add(new Models.ProductModel
            {
                Name = "asd",
                CategoryId = "T-Shirt",
                Count = 100,
                Price = 100,
                Description = "asd"
            });

            ctxt.SaveChanges();

            var result = ac.Index();

            //var res = mhc.Object.Index() as ViewResult;

            Assert.NotNull(result);
        }

        [Test]
        public void Detalis()
        {
            AdminController ac = new AdminController(ctxt);

            var res = ac.Details(null) as IActionResult;

            Assert.IsNull(res);
        }

        [Test]
        public void Create()
        {
            AdminController ac = new AdminController(ctxt);


            ctxt.Products.Add(new Models.ProductModel
            {
                Name = "asd",
                CategoryId = "T-Shirt",
                Count = 100,
                Price = 100,
                Description = "asd"
            });

            ctxt.SaveChanges();

            var res = ac.Create();

            Assert.NotNull(res);
        }

        [Test]
        public void Edit()
        {
            AdminController ac = new AdminController(ctxt);


            ctxt.Products.Add(new Models.ProductModel
            {
                Name = "asd",
                CategoryId = "T-Shirt",
                Count = 100,
                Price = 100,
                Description = "asd"
            });

            ctxt.SaveChanges();

            var res =  ac.Edit(ctxt.Products.FirstOrDefaultAsync().Id);

            Assert.NotNull(res);
        }
    }
}