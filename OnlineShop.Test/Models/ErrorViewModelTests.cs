using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OnlineShop.Tests.Models
{
    public class ErrorViewModelTests
    {
        [Test]
        public void TestErrorViewModelConstructionAndReqId()
        {
            ErrorViewModel em = new ErrorViewModel { RequestId = "1" };

            em.RequestId = "2";

            Assert.AreEqual("2", em.RequestId);
        }

        [Test]
        public void TestShowReqId()
        {
            ErrorViewModel em = new ErrorViewModel { RequestId = "1" };

            Assert.AreNotEqual(string.IsNullOrEmpty(em.RequestId), em.ShowRequestId);
        }
    }
}
