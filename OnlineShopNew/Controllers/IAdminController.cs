// <copyright file="AdminController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public interface IAdminController
    {
        IActionResult Create();
        
        Task<IActionResult> Create([Bind(new[] { "Id,CategoryId,Name,Price,Count,Description" })] ProductModel productModel);
        
        Task<IActionResult> Delete(int? id);
        
        Task<IActionResult> DeleteConfirmed(int id);
        
        Task<IActionResult> Details(int? id);
        
        Task<IActionResult> Edit(int id, [Bind(new[] { "Id,CategoryId,Name,Price,Count,Description" })] ProductModel productModel);
        
        Task<IActionResult> Edit(int? id);
        
        Task<IActionResult> Index();
    }
}