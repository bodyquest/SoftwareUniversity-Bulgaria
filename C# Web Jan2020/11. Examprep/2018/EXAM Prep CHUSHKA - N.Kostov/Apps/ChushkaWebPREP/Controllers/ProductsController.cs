namespace ChushkaWebPREP.Controllers
{
    using System;
    using System.Linq;
    using ChushkaWebPREP.Models;
    using ChushkaWebPREP.Models.Enums;
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
        public IHttpResponse Order(int id)
        {
            var user = this.Context.Users.FirstOrDefault(x=> x.Username == this.User.Username);
            if (user == null)
            {
                return this.BadRequestErrorWithView("Invalid user.");
            }

            var product = this.Context.Products.FirstOrDefault(x => x.Id == id);

            var order = new Order
            {
                OrderedOn = DateTime.UtcNow,
                ProductId = id,
                UserId = user.Id,
            };

            this.Context.Orders.Add(order);
            this.Context.SaveChanges();

            return this.Redirect("/");
        }

        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Create(CreateProductInputModel model)
        {
            if (!Enum.TryParse(model.Type, out ProductType type))
            {
                return this.BadRequestErrorWithView("Invalid type.");
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Type = type,

            };

            this.Context.Products.Add(product);
            var id = this.Context.SaveChanges();

            return this.Redirect("/Products/Details?id=" + product.Id);
        }

        [Authorize("Admin")]
        public IHttpResponse Edit(int id)
        {
            var product = this.Context.Products.Find(id);
            var model = new EditProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Type = product.Type,
                Price = product.Price,
            };

            return this.View(model);
        }

        //[Authorize("Admin")]
        //[HttpPost]
        //public IHttpResponse Edit(int id)
        //{
           
        //    var id = 1;

        //    return this.Redirect("/Products/Edit?id=" + id);
        //}

        //[Authorize]
        //public IHttpResponse Delete()
        //{
        //    return this.View();
        //}

        //[Authorize("Admin")]
        //[HttpPost]
        //public IHttpResponse Delete(DeleteProductModel model)
        //{

        //    var id = 1;

        //    return this.Redirect("/Products/Edit?id=" + id);
        //}
    }
}
