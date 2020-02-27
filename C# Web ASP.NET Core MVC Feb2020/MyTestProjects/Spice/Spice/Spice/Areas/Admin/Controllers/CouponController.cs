namespace Spice.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Spice.Models;
    using Spice.Services.Admin;
    using Spice.Services.Admin.Models.Coupons;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Admin")]
    public class CouponController : Controller
    {
        private readonly IWebHostEnvironment hostingEnv;
        private readonly ICouponService couponService;

        public CouponController(IWebHostEnvironment hostingEnv, ICouponService couponService)
        {
            this.hostingEnv = hostingEnv;
            this.couponService = couponService;
            this.CouponVM = Initialize();
        }

        private AdminCouponListingServiceModel Initialize()
        {
            var couponVM = new AdminCouponListingServiceModel();

            return couponVM;
        }

        [BindProperty]
        public AdminCouponListingServiceModel CouponVM { get; set; }

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

        //POST - Create
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminCouponListingServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var files = HttpContext.Request.Form.Files;

            if (files.Count > 0)
            {
                byte[] pic1 = null;
                using (var fileStream1 = files[0].OpenReadStream())
                {
                    using (var memoryStream1 = new MemoryStream())
                    {
                        fileStream1.CopyTo(memoryStream1);
                        pic1 = memoryStream1.ToArray();
                    }
                }

                model.Picture = pic1;
                bool isSuccessful = await this.couponService.CreateAsync(model);

                if (isSuccessful)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(model);
            }

            return this.View(model);
        }


        //GET - Edit
        [ActionName("Edit")]
        public async Task<IActionResult> EditAsync(int id)
        {
            this.CouponVM = await this.couponService.GetByIdAsync(id);

            if (this.CouponVM == null)
            {
                return NotFound();
            }

            return this.View(this.CouponVM);
        }

        //POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditAsync()
        {
            if (!ModelState.IsValid)
            {
                return this.View(CouponVM);
            }

            var files = HttpContext.Request.Form.Files;

            if (files.Count > 0)
            {
                byte[] newPic = null;

                using (var newFileStram = files[0].OpenReadStream())
                {
                    using (var newMemoryStream = new MemoryStream())
                    {
                        newFileStram.CopyTo(newMemoryStream);
                        newPic = newMemoryStream.ToArray();
                    }
                }

                CouponVM.Picture = newPic;

                bool isSuccessful = await this.couponService.UpdateAsync(CouponVM);

                if (isSuccessful)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(CouponVM);
            }

            return this.View(CouponVM);
        }



    }
}
