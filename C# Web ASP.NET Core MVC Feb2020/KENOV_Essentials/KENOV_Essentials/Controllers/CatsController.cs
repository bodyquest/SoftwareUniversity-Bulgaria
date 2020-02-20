namespace KENOV_Essentials.Controllers
{
    using KENOV_Essentials.Models;
    using KENOV_Essentials.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CatsController : Controller
    {
        private readonly ICatsService catsService;

        public CatsController(ICatsService catsService)
        {
            this.catsService = catsService;
        }

        public IActionResult Index() => this.View();

        //  /Cats/Details
        public object Details()
        {
            return "Test";
        }

        [Authorize]
        [HttpPost]
        public IActionResult Index(CatDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return this.View();
        }
    }
}
