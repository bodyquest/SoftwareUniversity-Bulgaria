namespace SharedTrip.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TripsController : Controller
    {
        public TripsController()
        {

        }
        public HttpResponse Login()
        {
            return this.View();
        }
    }
}
