using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using OnlineShop.Controllers;
using OnlineShop.Data;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using OnlineShop.Models;
using System.Linq;

namespace OnlineShop.Test
{
    [TestFixture]
    public class AdminControllerTests
    {
        private OnlineShopContext ctxt;
        private AdminController ac;

        [SetUp]
        public void Setup()
        {
            ac = new(ctxt);
            
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
            ctxt.Products.Add(new ProductModel
            {
                Name = "asd",
                CategoryId = 1,
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
            var res = ac.Details(1) as IActionResult;
            ac.Details(null);

            Assert.IsNull(res);
        }

        [Test]
        public void Create()
        {
            ac.Create();

            ProductModel pm = new ProductModel
            {
                Name = "asd",
                CategoryId = 1,
                Count = 100,
                Price = 100,
                Description = "asd"
            };

            ctxt.Products.Add(pm);

            ctxt.SaveChanges();

            var res = ac.Create(pm);

            Assert.NotNull(res);
        }

        [Test]
        public void Edit()
        {
            ac.Edit(null);

            ctxt.Products.Add(new ProductModel
            {
                Name = "asd",
                CategoryId = 1,
                Count = 100,
                Price = 100,
                Description = "asd"
            });

            ctxt.SaveChanges();
            
            var products = ctxt.Products.ToList();

            var res = ac.Edit(products.FirstOrDefault().Id);

            ViewResult result = res.Result as ViewResult;

            Assert.AreNotEqual("Edit" ,result.ViewName);
        }

        [Test]
        public void EditPost()
        {
            ProductModel pm = new ProductModel
            {
                Name = "asd",
                CategoryId = 1,
                Count = 100,
                Price = 100,
                Description = "asd"
            };

            Mock<ProductModel> pmock = new();

            ac.Edit(1, pmock.Object);

            ctxt.Products.Add(pm);
            ctxt.SaveChanges();

            ProductModel prod = ctxt.Products.FirstOrDefaultAsync().Result;

            var res = ac.Edit(ctxt.Products.FirstOrDefaultAsync().Id, prod);

            pm.Description = "asdjh123";

            var edit2 = ac.Edit(ctxt.Products.FirstOrDefaultAsync().Id, prod);

            prod.Name = "poredniq exception";

            ctxt.Update(prod);
            ctxt.Update(pm);

            Assert.AreEqual("asdjh123", pm.Description);
            Assert.AreNotEqual(pm.Name, "123j");
            Assert.NotNull(res.Id);
            Assert.AreEqual("poredniq exception", prod.Name);
        }

        [Test]
        public void Delete()
        {
            ac.Delete(null);

            ctxt.Products.Add(new ProductModel
            {
                Name = "asd",
                CategoryId = 1,
                Count = 100,
                Price = 100,
                Description = "asd"
            });

            ctxt.SaveChanges();

            var res = ac.Delete(ctxt.Products.FirstOrDefaultAsync().Id);

            Assert.NotNull(res.Id);
        }

        [Test]
        public void DeleteConfirmed()
        {
            ctxt.Products.Add(new ProductModel
            {
                Name = "asd",
                CategoryId = 1,
                Count = 100,
                Price = 100,
                Description = "asd"
            });

            ctxt.SaveChanges();

            var res = ac.DeleteConfirmed(ctxt.Products.FirstOrDefaultAsync().Id);

            Assert.NotNull(res.Id);
        }
    }
}