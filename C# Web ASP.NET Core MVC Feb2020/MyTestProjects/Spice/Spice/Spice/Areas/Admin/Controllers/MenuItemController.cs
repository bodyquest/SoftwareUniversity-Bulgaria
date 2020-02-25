namespace Spice.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Spice.Models.ViewModels;
    using Spice.Services.Admin;

    [Area("Admin")]
    public class MenuItemController : Controller
    {
        private readonly IWebHostEnvironment hostingEnv;
        private readonly IMenuItemService menuItemService;
        private readonly IAdminCategoryService categoryService;

        public MenuItemController(IWebHostEnvironment hostingEnv, IMenuItemService menuItemService, IAdminCategoryService categoryService)
        {
            this.hostingEnv = hostingEnv;
            this.menuItemService = menuItemService;
            this.categoryService = categoryService;
            MenuItemVM = InitializeAsync().Result;

        }

        private async Task<MenuItemViewModel> InitializeAsync()
        {
            var menuItemVM = new MenuItemViewModel();
            var categories = await this.categoryService.AllAsync();
            menuItemVM.Categories = categories;
            menuItemVM.MenuItem = new Models.MenuItem();

            return menuItemVM;
        }

        [BindProperty]
        public MenuItemViewModel MenuItemVM { get; set; }


        public async Task <IActionResult> Index()
        {
            var model = await this.menuItemService.GetAllAsync();

            return this.View(model);
        }

        //GET - Create
        public IActionResult Create()
        {
            return this.View(this.MenuItemVM);
        }
    }
}