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
            var model = this.Context.Products
            .Select (x => new EditDeleteProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Type = x.Type.ToString(),
                Price = x.Price,
            })
            .FirstOrDefault(x => x.Id == id);

            if (model == null)
            {
                return this.BadRequestErrorWithView("Invalid id.");
            }

            return this.View(model);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Edit(EditDeleteProductModel model)
        {
            var product = this.Context.Products.FirstOrDefault(x => x.Id == model.Id);

            if (product == null)
            {
                return this.BadRequestErrorWithView("Product not found.");
            }

            if (!Enum.TryParse(model.Type, out ProductType type))
            {
                return this.BadRequestErrorWithView("Invalid product type.");
            }

            product.Type = type;
            product.Description = model.Description;
            product.Name = model.Name;
            product.Price = model.Price;

            this.Context.Products.Update(product);
            this.Context.SaveChanges();

            return this.Redirect("/Products/Details?id=" + product.Id);
        }

        [Authorize]
        public IHttpResponse Delete(int id)
        {
            var model = this.Context.Products
            .Select(x => new EditDeleteProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Type = x.Type.ToString(),
                Price = x.Price,
            })
            .FirstOrDefault(x => x.Id == id);

            if (model == null)
            {
                return this.BadRequestErrorWithView("Invalid id.");
            }

            return this.View(model);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Delete(int id, string name)
        {
            var product = this.Context.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return this.Redirect("/");
            }

            this.Context.Remove(product);
            this.Context.SaveChanges();

            return this.Redirect("/");
        }
    }
}
