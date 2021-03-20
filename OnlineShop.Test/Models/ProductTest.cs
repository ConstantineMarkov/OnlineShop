using NUnit.Framework;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Tests
{
    public class ProductTest
    {
        [Test]
        public void TestIfProductModelIsValid()
        {
            ProductModel pm = new ProductModel
            {
                CategoryId = null,
                Count = 100,
                Description = "durabura",
                Name = "nishto",
                Price = 169,
                Id = 1
            };

            pm.Count = 120;

            Assert.AreEqual(120, pm.Count);
        }
    }
}
