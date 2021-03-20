// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public interface IHomeController
    {
        int CurrentPageIndex { get; set; }
        int PageCount { get; set; }

        IActionResult AboutUs();
        IActionResult Buy();
        Task<IActionResult> Buy(int? id, CartModel cart);
        Task<IActionResult> Cart();
        List<CartModel> CartList();
        IActionResult Error();
        Task<IActionResult> Index(int? pageNumber);
        Task<IActionResult> Order();
        Task<IActionResult> ProductView(int? id);
    }
}