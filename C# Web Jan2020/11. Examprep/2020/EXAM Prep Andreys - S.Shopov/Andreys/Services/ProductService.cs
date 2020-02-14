namespace Andreys.Services
{
    using Andreys.Data;
    using Andreys.Models;
    using Andreys.Models.Enums;
    using Andreys.ViewModels.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ProductService : IProductService
    {
        private readonly AndreysDbContext context;

        public ProductService(AndreysDbContext context)
        {
            this.context = context;
        }

        public void CreateProduct(string name, string description, string ImageUrl, string category, string gender, decimal price)
        {
            Enum.TryParse<ProductCategory>(category, out ProductCategory productCategory);
            Enum.TryParse<Gender>(gender, out Gender productGender);

            var product = new Product
            {
                Name = name,
                Description = description,
                ImageUrl = ImageUrl,
                Category = productCategory,
                Gender = productGender,
                Price = price
            };

            this.context.Products.Add(product);

            this.context.SaveChanges();
        }

        public void Delete(string id)
        {
            var product = this.context.Products.FirstOrDefault(x => x.Id == id);
            this.context.Products.Remove(product);
            this.context.SaveChanges();
        }

        public ProductListAllViewModel GetAll()
        {
            var model = new ProductListAllViewModel();
            model.ProductList = this.context.Products
                .Select(x => new ProductListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price
                }).ToList();

            return model;
        }

        public ProductDetailsViewModel GetDetails(string id)
        {
            var model = this.context.Products
                .Select(x => new ProductDetailsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Gender = x.Gender,
                    Category = x.Category,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Price = x.Price
                })
                .FirstOrDefault(x => x.Id == id);

            return model;
        }
    }
}
