namespace Andreys.Services
{
    using Andreys.ViewModels.Products;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IProductService
    {
        void CreateProduct(string name, string description, string ImageUrl, string category, string gender, decimal price);

        ProductDetailsViewModel GetDetails(string id);

        ProductListAllViewModel GetAll();

        void Delete(string id);
    }
}
