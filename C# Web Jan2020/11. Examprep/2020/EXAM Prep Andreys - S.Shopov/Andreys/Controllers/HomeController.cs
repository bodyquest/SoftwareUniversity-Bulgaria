namespace Andreys.App.Controllers
{
    using Andreys.Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var model = this.productService.GetAll();

                return this.View(model, "/Home");
            }

            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse IndexFull()
        {
            return this.Index();
        }
    }
}
