using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spice.Data;
using Spice.Services.Admin;

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
    }
}