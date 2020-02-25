namespace Spice.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Spice.Models.ViewModels;
    using Spice.Services.Admin;
    using Spice.Utility;

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

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost()
        {
            MenuItemVM.MenuItem.SubcategoryId = int.Parse(this.Request.Form["SubcategoryId"].ToString());

            if (!ModelState.IsValid)
            {
                return this.View(this.MenuItemVM);
            }

            await this.menuItemService.CreateAsync(MenuItemVM.MenuItem);

            string webRootPath = hostingEnv.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var menuItemFromDb = await this.menuItemService.GetByIdAsync(MenuItemVM.MenuItem.Id);

            if (files.Count > 0)
            {
                // if file has been uploaded

                var uploads = Path.Combine(webRootPath, "img");

                // whatever is the first file extension, this will be the required for the rest of the files.

                var extension = Path.GetExtension(files[0].FileName);

                using (var filesStream = new FileStream(Path.Combine(uploads, menuItemFromDb.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }

                menuItemFromDb.Image = @"\img\" + menuItemFromDb.Id + extension;
            }
            else
            {
                // no file was uploded, so use default

                var uploads = Path.Combine(webRootPath, @"img\" + StaticDetails.DefaultFoodImage);

                System.IO.File.Copy(uploads, @"\img\" + menuItemFromDb.Id + ".jpg");

                menuItemFromDb.Image = @"\img\" + menuItemFromDb.Id + ".jpg";
            }

            await this.menuItemService.UpdateItemImageAsync(menuItemFromDb);

            return this.RedirectToAction(nameof(Index));
        }
    }
}