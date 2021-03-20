using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using OnlineShop.Data;

namespace OnlineShop.Tests
{
    public class CartModelTest
    {
        [Test]
        public void TestIfCardIsValid()
        {
            CartModel cartModel = new CartModel { Id = 1, Count = 100, ProductId = 1 };
            
            cartModel.Id = 2;
            cartModel.UserId = "1";
            
            cartModel.User = new Mock<OnlineShopUser>().Object;
            cartModel.Product = new Mock<ProductModel>().Object;

            Assert.AreEqual(2, cartModel.Id);
        }
    }
}
