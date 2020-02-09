namespace ChushkaWebPREP.Controllers
{
    using ChushkaWebPREP.ViewModels.Home;
    using SIS.HTTP.Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var products = this.Context
                    .Products
                    .Select(x => new ProductViewModel 
                     {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price,
                        Description = x.Description 
                     });

                var model = new IndexViewModel 
                {
                    Products = products
                };

                return this.View("Home/IndexLoggedIn", model);
            }

            return this.View();
        }
    }
}
