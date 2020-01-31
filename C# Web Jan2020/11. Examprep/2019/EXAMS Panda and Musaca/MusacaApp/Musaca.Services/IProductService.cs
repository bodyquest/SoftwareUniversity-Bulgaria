namespace Musaca.Services
{
    using System.Collections.Generic;

    using Musaca.Models;

    public interface IProductService
    {
        Product CreateProduct(Product product);

        Product GetByName(string name);

        List<Product> GetAllProducts();
    }
}
