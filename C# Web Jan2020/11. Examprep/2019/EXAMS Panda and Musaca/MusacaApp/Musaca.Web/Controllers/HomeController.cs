namespace Musaca.Web.Controllers
{
    using Musaca.Models;
    using Musaca.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Mapping;
    using SIS.MvcFramework.Attributes;
    using Musaca.Web.ViewModels.Orders;
    using Musaca.Web.ViewModels.Products;

    public class HomeController : Controller
    {
        private readonly IOrderService orderService;

        public HomeController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        // /Home/Index
        public IActionResult Index()
        {
            OrderHomeViewModel orderHomeViewModel = new OrderHomeViewModel();

            if (this.IsLoggedIn())
            {
                Order order = this.orderService.GetActiveOrderByCashierId(this.User.Id);

                orderHomeViewModel = order.To<OrderHomeViewModel>();

                orderHomeViewModel.Products.Clear();

                foreach (var item in order.Products)
                {
                    ProductHomeViewModel productHomeViewModel = item.Product.To<ProductHomeViewModel>();

                    orderHomeViewModel.Products.Add(productHomeViewModel);
                }
            }

            return this.View(orderHomeViewModel);
        }
    }
}
