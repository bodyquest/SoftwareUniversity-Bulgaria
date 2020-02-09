namespace ChushkaWebPREP.Controllers
{
    using System.Linq;

    using ChushkaWebPREP.ViewModels.Products;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;

    public class ProductsController : BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var viewModel = this.Context.Products
                .Select(x => new ProductDetailsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Price = x.Price,
                    Description = x.Description,
                })
                .FirstOrDefault(x => x.Id == id);

            if (viewModel == null)
            {
                return this.BadRequestError("Invalid product id.");
            }

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IHttpResponse Order(int id)
        {
            return this.Redirect("");
        }
    }
}
