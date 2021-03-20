namespace OnlineShop.Test
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
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
    
    class HomeControllerTests
    {
        private static Mock<IUserStore<OnlineShopUser>> userStore;
        private UserManager<OnlineShopUser> userManager;
        private Mock<ILogger<HomeController>> logger;
        private OnlineShopContext context;
        private HomeController hc;

        [SetUp]
        public void SetUp()
        {
            var opt = new DbContextOptionsBuilder<OnlineShopContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            this.context = new OnlineShopContext(opt);

            userStore = new Mock<IUserStore<OnlineShopUser>>();
            userManager = new UserManager<OnlineShopUser>(userStore.Object, null, null, null, null, null, null, null, null);
            logger = new Mock<ILogger<HomeController>>();

            hc = new(logger.Object, userManager, context);
        }

        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }

        [Test]
        public void Index()
        {
            var res = hc.Index(1);

            Assert.IsNotNull(res.Id);
        }

        [Test]
        public void Cart()
        {
            var res = hc.Cart();

            Assert.IsNotNull(res.Id);
        }

        [Test]
        public void AboutUs()
        {
            var res = hc.AboutUs();

            Assert.IsNotNull(res);
        }

        [Test]
        public void ProductView()
        {
            hc.ProductView(null);
            var res = hc.ProductView(1);

            Assert.NotNull(res.Id);
        }

        [Test]
        public void Buy()
        {
            var res = hc.Buy();

            ViewResult viewResult = res as ViewResult;

            Assert.NotNull(viewResult.Model.ToString());
        }

        [Test]
        public void BuyPost()
        {
            Mock<CartModel> cm = new Mock<CartModel>();

            context.Add(cm.Object);
            context.SaveChanges();

            hc.Buy(1, null);
            var res = hc.Buy(1, cm.Object);

            int m = cm.Object.Count;

            Assert.AreEqual(0, m);
            Assert.NotNull(res);
        }

        [Test]
        public void Order()
        {
            var res = hc.Order();
            Assert.NotNull(res);
        }

        [Test]
        public void Privacy()
        {
            Assert.NotNull(hc.Privacy());
        }
    }
}
