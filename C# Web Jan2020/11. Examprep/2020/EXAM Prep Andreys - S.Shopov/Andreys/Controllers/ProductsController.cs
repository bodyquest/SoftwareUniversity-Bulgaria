namespace Andreys.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProductsController : Controller
    {
        public ProductsController()
        {

        }

        [HttpGet("/Products/Add")]
        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }


            return this.View();
        }
        
        [HttpPost("/Products/Add")]
        public HttpResponse Add(int id)  //add ViewModel
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }



            return this.Redirect("/");
        }

        [HttpGet("/Products/Details")]
        public HttpResponse Details()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }



            return this.View();
        }
    }
}
