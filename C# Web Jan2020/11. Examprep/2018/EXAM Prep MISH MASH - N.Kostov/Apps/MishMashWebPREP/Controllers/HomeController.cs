namespace MishMashWebPREP.Controllers
{
    using SIS.HTTP.Responses;
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
}
