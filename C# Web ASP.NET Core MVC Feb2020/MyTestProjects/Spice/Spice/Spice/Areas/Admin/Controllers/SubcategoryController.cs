using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.ViewModels;
using Spice.Services.Admin.Models;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubcategoryController : Controller
    {
        private readonly IAdminSubcategoryService adminSubcategoryService;
        private readonly ApplicationDbContext context;

        public SubcategoryController(IAdminSubcategoryService adminSubcategoryService, ApplicationDbContext context)
        {
            this.adminSubcategoryService = adminSubcategoryService;
            this.context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        // GET - Index
        public async Task<IActionResult> Index()
        {
            var model = await this.adminSubcategoryService.AllSubcategoriesAsync();

            return this.View(model);
        }


        // GET - Create
        public async Task<IActionResult> CreateAsync()
        {
            var model = await this.adminSubcategoryService.GetCreateAsync();

            return this.View(model);
        }


        // POST - Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsyc(SubcategoryAndCategoryViewModel model)
        {
            var modelVM = await this.adminSubcategoryService.GetCreateAsync();

            if (ModelState.IsValid)
            {
                var subcategoryExists = await this.adminSubcategoryService.CreateAsync(model.Subcategory.Name, model.Subcategory.CategoryId);

                if (subcategoryExists == null)
                {
                    StatusMessage = "Error : Subcategory already exists";

                    modelVM.Subcategory = model.Subcategory;
                    modelVM.StatusMessage = StatusMessage;

                    return this.View(modelVM);
                } 

                return RedirectToAction(nameof(Index));
            }
            
            return this.View(modelVM); 
        }


        [ActionName("GetSubcategory")]
        public async Task<IActionResult> GetSubcategory(int id)
        {
            var model = await this.adminSubcategoryService.GetListAsync(id);

            return Json(new SelectList(model, "Id", "Name"));
        }


        // GET - Edit
        public async Task<IActionResult> EditAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await this.adminSubcategoryService.GetEditAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return this.View(model);
        }


        // POST - Edit
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsyc(SubcategoryAndCategoryViewModel model)
        {
            var modelVM = await this.adminSubcategoryService.GetEditAsync(model.Subcategory.Id);

            if (ModelState.IsValid)
            {
                var subcategoryExists = await this.adminSubcategoryService.ExistsAsync(model.Subcategory.Name, model.Subcategory.CategoryId);

                if (subcategoryExists) 
                {
                    StatusMessage = "Error : Subcategory already exists";

                    modelVM.Subcategory = model.Subcategory;
                    modelVM.StatusMessage = StatusMessage;

                    return this.View(modelVM);
                }

                var updated = await this.adminSubcategoryService.UpdateAsync(model.Subcategory.Id, model.Subcategory.Name);

                if (updated)
                {
                    return RedirectToAction(nameof(Index));
                }
                
                return this.View(modelVM);
            }

            return this.View(modelVM);
        }

    }
}