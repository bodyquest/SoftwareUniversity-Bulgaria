namespace Andreys.Controllers
{
    using Andreys.Services;
    using Andreys.ViewModels.Products;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }
        
        [HttpPost("/Products/Add")]
        public HttpResponse Add(CreateProductInputViewModel model)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.productService.CreateProduct(model.Name, model.Description, model.ImageUrl, model.Category, model.Gender, model.Price);

            return this.Redirect("/");
        }

        [HttpGet("/Products/Delete")]
        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.productService.Delete(id);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var model = this.productService.GetDetails(id);

            return this.View(model);
        }
    }
}
