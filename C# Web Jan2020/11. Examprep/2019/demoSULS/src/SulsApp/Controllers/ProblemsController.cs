namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.HTTP.Response;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProblemsController : Controller
    {
        public HttpResponse Create(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Details(HttpRequest request)
        {
            return this.View();
        }
    }
}
