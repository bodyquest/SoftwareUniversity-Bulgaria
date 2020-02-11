namespace MishMashWebPREP.Controllers
{
    using MishMashWebPREP.ViewModels.Home;
    using SIS.HTTP.Responses;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var model = new IndexViewModel
                {

                };

                return this.View("Home/IndexLoggedIn");
            }

            return this.View("Home/Index");
        }
    }
}
