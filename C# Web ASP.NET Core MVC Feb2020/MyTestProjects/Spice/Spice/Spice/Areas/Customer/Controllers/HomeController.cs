using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spice.Models;
using Spice.Models.ViewModels;
using Spice.Services.Admin;

namespace Spice.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICouponService couponService;
        private readonly IMenuItemService menuItemService;
        private readonly IAdminCategoryService categoryService;

        public HomeController(ILogger<HomeController> logger, ICouponService couponService, IMenuItemService menuItemService, IAdminCategoryService categoryService)
        {
            _logger = logger;
            this.couponService = couponService;
            this.menuItemService = menuItemService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var itemMenus = await this.menuItemService.GetAllAsync();
            var itemCategorys = await this.categoryService.AllAsync();
            var itemCoupons = await this.couponService.AllAsync();

            var model = new IndexViewModel()
            {
                MenuItems = itemMenus,
                Categories = itemCategorys.OrderBy(x => x.Name),
                Coupons = itemCoupons
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
