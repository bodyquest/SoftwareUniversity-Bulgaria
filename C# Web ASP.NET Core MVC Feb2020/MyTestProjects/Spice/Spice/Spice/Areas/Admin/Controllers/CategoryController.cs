using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spice.Data;
using Spice.Services.Admin;
using Spice.Services.Admin.Models;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IAdminCategoryService adminCategoryService;

        public CategoryController(IAdminCategoryService adminCategoryService)
        {
            this.adminCategoryService = adminCategoryService; 
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.adminCategoryService.AllCategoriesAsync();

            return View(model);
        }

        // GET - Create
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminCategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await this.adminCategoryService.CreateAsync(model.Name);

                return RedirectToAction(nameof(Index));
            }

            return this.View(model);
        }
    }
}