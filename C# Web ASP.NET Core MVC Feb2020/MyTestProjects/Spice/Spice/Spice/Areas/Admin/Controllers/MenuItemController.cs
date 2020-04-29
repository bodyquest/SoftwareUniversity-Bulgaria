namespace Spice.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Spice.Data;
    using Spice.Models;
    using Spice.Models.Enums;
    using Spice.Models.ViewModels;
    using Spice.Services.Admin;
    using Spice.Services.Admin.Models;
    using Spice.Utility;

    [Area("Admin")]
    public class MenuItemController : Controller
    {
        private readonly IWebHostEnvironment hostingEnv;
        private readonly IMenuItemService menuItemService;
        private readonly IAdminCategoryService categoryService;
        private readonly IAdminSubcategoryService subcategoryService;

        public MenuItemController(IWebHostEnvironment hostingEnv, IMenuItemService menuItemService, IAdminCategoryService categoryService, IAdminSubcategoryService subcategoryService)
        {
            this.hostingEnv = hostingEnv;
            this.menuItemService = menuItemService;
            this.categoryService = categoryService;
            this.subcategoryService = subcategoryService;
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

        private async Task<IActionResult> GetModelwithSubcategoriesAsync()
        {
            var subcategories = await this.subcategoryService.GetListAsync(MenuItemVM.MenuItem.CategoryId);
            this.MenuItemVM.Subcategories = subcategories.Select(x => new Subcategory
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            var spicy = ((SpicynessLevel)(int.Parse(this.MenuItemVM.MenuItem.Spicyness)));
            this.MenuItemVM.Spicyness = spicy.ToString();

            return this.View(this.MenuItemVM);
        }


        public async Task<IActionResult> Index()
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
        public async Task<IActionResult> CreateAsync()
        {
            MenuItemVM.MenuItem.SubcategoryId = int.Parse(this.Request.Form["SubcategoryId"].ToString());

            if (!ModelState.IsValid)
            {
                return this.View(this.MenuItemVM);
            }

            string webRootPath = hostingEnv.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var filePath = Path.GetTempFileName();

            await this.menuItemService.CreateAsync(MenuItemVM.MenuItem);


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

                menuItemFromDb.Image = @"\img\" + MenuItemVM.MenuItem.Id + extension;
            }
            else
            {
                // no file was uploded, so use default

                var uploads = Path.Combine(webRootPath, @"img\" + StaticDetails.DefaultFoodImage);

                System.IO.File.Copy(uploads, webRootPath + @"\img\" + MenuItemVM.MenuItem.Id + ".jpg");

                menuItemFromDb.Image = @"\img\" + MenuItemVM.MenuItem.Id + ".jpg";
            }

            await this.menuItemService.UpdateItemImageAsync(menuItemFromDb);

            return this.RedirectToAction(nameof(Index));
        }



        //GET - Edit
        [ActionName("Edit")]
        public async Task<IActionResult> EditAsync(int id)
        {
            this.MenuItemVM.MenuItem = await this.menuItemService.GetByIdAsync(id);

            if (this.MenuItemVM.MenuItem == null)
            {
                return NotFound();
            }

            return await GetModelwithSubcategoriesAsync();
        }

        //POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditAsync()
        {
            MenuItemVM.MenuItem.SubcategoryId = int.Parse(this.Request.Form["SubcategoryId"].ToString());

            #region test smth
            string test = "str";
            var array = new string[] { "vm", "model" };

            var result = array.Any(test.Contains);
            #endregion

            if (!ModelState.IsValid)
            {
                return await GetModelwithSubcategoriesAsync();
            }

            //await this.menuItemService.CreateAsync(MenuItemVM.MenuItem);

            string webRootPath = hostingEnv.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var menuItemFromDb = await this.menuItemService.GetByIdAsync(MenuItemVM.MenuItem.Id);

            if (files.Count > 0)
            {
                // new image file has been uploaded
                var uploads = Path.Combine(webRootPath, "img");
                var extension_new = Path.GetExtension(files[0].FileName);

                // delete the original file
                if (menuItemFromDb.Image != null)
                {
                    var imagePath = Path.Combine(webRootPath, menuItemFromDb.Image.TrimStart('\\'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                // upload the new file
                using (var filesStream = new FileStream(Path.Combine(uploads, menuItemFromDb.Id + extension_new), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }

                menuItemFromDb.Image = @"\img\" + MenuItemVM.MenuItem.Id + extension_new;
            }

            menuItemFromDb.Name = MenuItemVM.MenuItem.Name;
            menuItemFromDb.Description = MenuItemVM.MenuItem.Description;
            menuItemFromDb.Price = MenuItemVM.MenuItem.Price;
            menuItemFromDb.Spicyness = MenuItemVM.MenuItem.Spicyness;
            menuItemFromDb.CategoryId = MenuItemVM.MenuItem.CategoryId;
            menuItemFromDb.SubcategoryId = MenuItemVM.MenuItem.SubcategoryId;

            await this.menuItemService.UpdateAsync(menuItemFromDb);

            return this.RedirectToAction(nameof(Index));
        }



        //GET - Details
        [ActionName("Details")]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            this.MenuItemVM.MenuItem = await this.menuItemService.GetByIdAsync(id);

            if (this.MenuItemVM.MenuItem == null)
            {
                return NotFound();
            }

            return await GetModelwithSubcategoriesAsync();
        }



        //GET - Delete
        public async Task<IActionResult> DeleteAsync(int id)
        {
            this.MenuItemVM.MenuItem = await this.menuItemService.GetByIdAsync(id);

            if (this.MenuItemVM.MenuItem == null)
            {
                return NotFound();
            }

            return await GetModelwithSubcategoriesAsync();
        }

        //POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteAsync()
        {
            string webRootPath = hostingEnv.WebRootPath;

            var menuItemFromDb = await this.menuItemService.GetByIdAsync(MenuItemVM.MenuItem.Id);

            // delete the original image file
            if (menuItemFromDb.Image != null)
            {
                var imagePath = Path.Combine(webRootPath, menuItemFromDb.Image.TrimStart('\\'));

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            await this.menuItemService.DeleteAsync(menuItemFromDb);

            return this.RedirectToAction(nameof(Index));
        }
    }
}