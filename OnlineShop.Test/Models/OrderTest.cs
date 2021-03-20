using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlineShop.Models;

namespace OnlineShop.Tests
{
    public class OrderTest
    {
        [Test]
        public void OrderModelTestIfValid()
        {
            var om = new OrderModel { Id = 1, Count = 100, Date = DateTime.Now, Product = null };
            om.Product = new ProductModel
            {
                Count = 100,
                //CategoryId = null,
                Description = "alo da",
                Name = "trash",
                Price = 100,
            };

            Assert.AreEqual(1, om.Id);
        }
    }
}
