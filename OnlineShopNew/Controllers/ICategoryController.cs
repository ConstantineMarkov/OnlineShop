using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    interface ICategoryController
    {
        IActionResult Create();

        Task<IActionResult> Create([Bind(new[] { "Id,Name" })] CategoryModel categoryModel);

        Task<IActionResult> Delete(int? id);

        Task<IActionResult> DeleteConfirmed(int id);

        Task<IActionResult> Details(int? id);

        Task<IActionResult> Edit(int id, [Bind(new[] { "Id,Name" })] CategoryModel categoryModel);

        Task<IActionResult> Edit(int? id);

        Task<IActionResult> Index();
    }
}
