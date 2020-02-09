namespace ChushkaWebPREP.Controllers
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            return this.View();
        }
    }

    public class BaseController : Controller
    {
        public BaseController()
        {

        }
    }
}
