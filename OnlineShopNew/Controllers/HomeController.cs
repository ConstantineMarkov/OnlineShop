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
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using OnlineShop.Data;
    using OnlineShop.Models;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private AppDbContext db = new AppDbContext();

        public int CurrentPageIndex { get; set; }

        public const int maxItemDisplay = 9;

        public int PageCount { get; set; }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            var products = from s in db.Products select s;
            int pageSize = 9;
            return View(await PaginatedList<ProductModel>.CreateAsync(products, pageNumber ?? 1, pageSize));
        }

        public IActionResult AboutUs()
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
