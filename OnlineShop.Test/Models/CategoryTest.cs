using NUnit.Framework;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Tests
{
    public class CategoryTest
    {
        [Test]
        public void TestIfCategoryModelIsValid()
        {
            CategoryModel categoryModel = new CategoryModel { Id = 1, Name = "alabala", };
            categoryModel.Id = 2;

            Assert.AreEqual(2, categoryModel.Id);
        }
    }
}
