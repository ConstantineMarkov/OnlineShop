using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class CategoryController : Controller, ICategoryController
    {
        private readonly OnlineShopContext _context;

        public CategoryController(OnlineShopContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(new[] { "Id,Name" })] CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(categoryModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.CategoryModel
                .FirstOrDefaultAsync(m => m.Id == id);

            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.CategoryModel.FindAsync(id);

            _context.CategoryModel.Remove(categoryModel);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.CategoryModel
                .FirstOrDefaultAsync(m => m.Id == id);

            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(new[] { "Id,Name" })] CategoryModel categoryModel)
        {
            if (id != categoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryModelExists(categoryModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                return RedirectToAction(nameof(Index));
            }
            
            return View(categoryModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.CategoryModel.FindAsync(id);

            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoryModel.ToListAsync());
        }

        private bool CategoryModelExists(int id)
        {
            return _context.CategoryModel.Any(e => e.Id == id);
        }
    }
}
