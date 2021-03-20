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

    public class HomeController : Controller, IHomeController
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<OnlineShopUser> userManager;
        private OnlineShopContext db;

        private const int maxItemDisplay = 9;
        private int CurrentPageIndex { get; set; }
        private int PageCount { get; set; }

        public HomeController(ILogger<HomeController> logger,
            UserManager<OnlineShopUser> userManager,
            OnlineShopContext context)
        {   
            this.userManager = userManager;
            _logger = logger;
            db = context;
        }

        public List<CartModel> CartList()
        {
            var CartList = db.CartModel.Where(x => x.UserId == userManager.GetUserId(this.User)).ToList();
            
            return CartList;
        }
            
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
            if (db.CartModel != null && db.CartModel.Any())
            {
                cart.Id = db.CartModel.Select(x => x.Id).Max() + 1;
            }
            else cart.Id = 1;

            var productModel = await db.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (productModel.Count < cart.Count)
            {
                throw new InvalidOperationException("Not enough products.");
            }

            productModel.Count -= cart.Count;

            OnlineShopUser user = await this.userManager.GetUserAsync(this.User);

            cart.UserId = user.Id;

            cart.ProductId = productModel.Id;
            //cart.Product = db.Products.Where(x => x.Id == cart.ProductId).FirstOrDefault();

            db.Add(cart);
            await db.SaveChangesAsync();
            return View(nameof(ProductView), productModel);

            return View(cart);
        }

        public async Task<IActionResult> Order()
        {
            var cartList = CartList();

            foreach (var item in cartList)
            {
                OrderModel order = new OrderModel();
                order.ProductId = item.ProductId;
                order.Count = item.Count;
                db.Add(order);
                await db.SaveChangesAsync();
            }

            db.Database.ExecuteSqlRaw("TRUNCATE TABLE cart");

            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
