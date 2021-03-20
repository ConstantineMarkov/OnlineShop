using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using OnlineShop.Controllers;
using OnlineShop.Data;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Test
{
    class CategoryControllerTests
    {
        private OnlineShopContext context;
        private CategoryController cc;

        [SetUp]
        public void SetUp()
        {
            var opt = new DbContextOptionsBuilder<OnlineShopContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            this.context = new(opt);

            cc = new(context);
        }

        [Test]
        public void Create()
        {
            var res = cc.Create();
            Assert.NotNull(res);
        }

        [Test]
        public void CreatePost()
        {
            Mock<CategoryModel> cmot = new();

            var res = cc.Create(cmot.Object);

            Assert.NotNull(res);
        }

        [Test]
        public void Delete()
        {
            var res = cc.Delete(1);
            var nullRes = cc.Delete(null);

            Assert.NotNull(res);
        }

        [Test]
        public void DeleteConfirmed()
        {
            var res = cc.DeleteConfirmed(1);
            var nullRes = cc.DeleteConfirmed(null);

            Assert.NotNull(res);
        }

        [Test]
        public void Details()
        {
            Mock<CategoryModel> cm = new();

            cm.Object.Id = default;

            var res = cc.Details(1);
            
            var nullRes = cc.Details(null);

            var defRes = cc.Details(cm.Object.Id);

            Assert.NotNull(res);
        }

        [Test]
        public void Edit()
        {
            Mock<CategoryModel> cm = new();
            
            cm.Object.Id = 1;

            var res = cc.Edit(1, cm.Object);

            cm.Object.Id = default;
            cm.Object.Id = 2;

            cc.Edit(1, cm.Object);

            Assert.NotNull(res);
        }

        [Test]
        public void EditWithIntOnly()
        {
            Mock<CategoryModel> cm = new();

            var res = cc.Edit(1);
            var nullRes = cc.Edit(null);

            Assert.NotNull(res);
        }

        [Test]
        public void Index()
        {
            Assert.NotNull(cc.Index());
        }
    }
}
