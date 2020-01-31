namespace Musaca.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Musaca.Data;
    using Musaca.Models;

    public class ProductService : IProductService
    {
        private readonly MusacaDbContext context;

        public ProductService(MusacaDbContext MusacaDbContext)
        {
            this.context = MusacaDbContext;
        }

        public Product CreateProduct(Product product)
        {
            this.context.Add(product);
            this.context.SaveChanges();

            return product;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> allProductsFromDb = this.context.Products.ToList();

            return allProductsFromDb;
        }

        public Product GetByName(string name)
        {
            Product productFromDb = this.context.Products.SingleOrDefault(x => x.Name == name);

            return productFromDb;
        }
    }
}
