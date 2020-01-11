namespace IRunes.App.Controllers
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Requests;

    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest httpRequest)
        {
            if (this.IsLoggedIn(httpRequest))
            {
                this.ViewData["Username"] = httpRequest.Session.GetParameter("username");

                return this.View("Home");
            }

            return this.View();
        }
    }
}
