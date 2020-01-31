namespace Musaca.Web.ViewModels.Orders
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using Musaca.Web.ViewModels.Products;

    public class OrderHomeViewModel
    {
        public OrderHomeViewModel()
        {
            this.Products = new List<ProductHomeViewModel>();
        }

        public List<ProductHomeViewModel> Products { get; set; }

        public decimal Price => this.Products.Sum(product => product.Price);
    }
}
