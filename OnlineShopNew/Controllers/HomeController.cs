// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OnlineShop.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using OnlineShop.Data;
    using OnlineShop.Models;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private OnlineShopContext db = new OnlineShopContext();
        private UserManager<OnlineShopUser> userManager;
        public const int maxItemDisplay = 9;

        public HomeController(ILogger<HomeController> logger, UserManager<OnlineShopUser> userManager)
        {
            this.userManager = userManager;
            _logger = logger;
        }
        
        public List<CartModel> CartList()
        {
            var CartList = db.CartModel.ToList();
            return CartList;
        }

        public int CurrentPageIndex { get; set; }

        public int PageCount { get; set; }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            var products = from s in db.Products select s;
            int pageSize = 9;
            return View(await PaginatedList<ProductModel>.CreateAsync(products, pageNumber ?? 1, pageSize));
        }
        
        public async Task<IActionResult> Cart()
        {
            return View(CartList());
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProductView(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var a = CartList();
            var productModel = await db.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        public IActionResult Buy()
        {
            return View("Buy", new CartModel());
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int? id, CartModel cart)
        {
            if (CartList() != null && CartList().Any())
            {
                cart.Id = db.CartModel.Select(x => x.Id).Max() + 1;
            }
            else cart.Id = 1;
            var productModel = await db.Products.FirstOrDefaultAsync(m => m.Id == id);
            if(productModel.Count < cart.Count)
            {
                throw new InvalidOperationException("Not enough products.");
            }
            productModel.Count -= cart.Count;
            OnlineShopUser user = await this.userManager.GetUserAsync(this.User);
            cart.UserId = user.Id;

            cart.ProductId = productModel.Id;
            //cart.Product = db.Products.Where(x => x.Id == cart.ProductId).FirstOrDefault();
            var b = CartList();
            //if (ModelState.IsValid)
            {
                db.Add(cart);
                await db.SaveChangesAsync();
                return View(nameof(ProductView), productModel);
            }

            return View(cart);
        }

        public IActionResult Order()
        {
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE cart");
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
