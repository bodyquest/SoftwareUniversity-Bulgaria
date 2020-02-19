namespace _02.DemoCoreMVCApp.Controllers
{
    using _02.DemoCoreMVCApp.Models.CarAd;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarAdController : Controller
    {
        public CarAdController()
        {

        }

        public IActionResult Create()
        {
            var model = new CarInputModel();
            model.ReleaseDate = DateTime.UtcNow;

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create([FromForm]CarInputModel model)
        {
            if (ModelState.IsValid)
            {
                return this.View(model);
            }

            return this.View(model);
        }
    }
}
