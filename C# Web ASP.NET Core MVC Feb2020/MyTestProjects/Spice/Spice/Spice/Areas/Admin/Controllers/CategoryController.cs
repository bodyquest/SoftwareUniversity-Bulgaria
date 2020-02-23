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

        // POST - Create
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

        //GET - Edit
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var model = await this.adminCategoryService.GetAsync(id);

            return this.View(model);
        }

        //POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (AdminCategoryEditDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await this.adminCategoryService.UpdateAsync(model.Id, model.Name);

                if (isUpdated)
                {
                    return RedirectToAction(nameof(Index));
                }

                return this.View(model);
            }

            return this.View(model);
        }

        //GET - Delete
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var model = await this.adminCategoryService.GetAsync(id);

            return this.View(model);
        }

        //POST - Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var isDeleted = await this.adminCategoryService.DeleteAsync(id);

            if (!isDeleted)
            {
                return this.View();
            }

            return this.RedirectToAction(nameof(Index));
        }

        //GET - Details
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var model = await this.adminCategoryService.GetAsync(id);

            return this.View(model);
        }
    }
}