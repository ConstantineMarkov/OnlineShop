using System;
using OnlineShop.Models;
using NUnit;
using NUnit.Framework;

namespace OnlineShop.Tests
{
    public class BuyingHistoryTest
    {
        [Test]
        public void TestIfIsInvalid()
        {
            var hist = new BuyingHistory { AccountId = null, Id = 1, OrderId = null};
            hist.Id = 1;
            //Assert
            Assert.AreEqual(1, hist.Id);
        }
    }
}
