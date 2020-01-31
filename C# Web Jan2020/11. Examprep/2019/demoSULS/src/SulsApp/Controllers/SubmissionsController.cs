namespace SulsApp.Controllers
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using SIS.HTTP;
    using SIS.HTTP.Response;
    using SIS.MvcFramework;

    public class SubmissionsController : Controller
    {
        public HttpResponse Create(HttpRequest request)
        {
            return this.View();
        }
    }
}
