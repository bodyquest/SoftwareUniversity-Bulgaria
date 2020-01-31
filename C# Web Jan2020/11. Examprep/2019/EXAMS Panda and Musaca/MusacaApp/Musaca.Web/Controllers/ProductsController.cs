namespace Musaca.Web.Controllers
{
    using System.Linq;

    using Musaca.Models;
    using Musaca.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Mapping;
    using SIS.MvcFramework.Attributes;
    using Musaca.Web.ViewModels.Products;
    using Musaca.Web.BindingModels.Products;
    using SIS.MvcFramework.Attributes.Security;

    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public ProductsController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }

        [Authorize]
        public IActionResult All()
        {
            return this.View(this.productService.GetAllProducts().To<ProductAllViewModel>().ToList());
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ProductCreateBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.productService.CreateProduct(bindingModel.To<Product>());

            return this.Redirect("All");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Order(ProductOrderBindingModel productOrderBindingModel)
        {
            Product product = this.productService.GetByName(productOrderBindingModel.Product);

            this.orderService.AddProductToActiveOrder(product.Id, this.User.Id);

            return this.Redirect("/");
        }
    }
}
