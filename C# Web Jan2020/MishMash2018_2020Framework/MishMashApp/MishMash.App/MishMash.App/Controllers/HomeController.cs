namespace MishMash.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                return this.View("");
            }

            return this.View();
        }

        [HttpGet("/")]
        public HttpResponse SlashIndex()
        {
            return this.Index();
        }
    }
}
