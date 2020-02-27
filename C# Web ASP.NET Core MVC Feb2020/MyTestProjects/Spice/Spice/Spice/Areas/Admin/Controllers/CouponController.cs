namespace Spice.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Spice.Services.Admin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Admin")]
    public class CouponController : Controller
    {
        private readonly ICouponService couponService;

        public CouponController(ICouponService couponService)
        {
            this.couponService = couponService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.couponService.AllAsync();

            return this.View(model);
        }

        //GET - Create
        public IActionResult Create()
        {

            return this.View();
        }

    }
}
