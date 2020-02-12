namespace Andreys.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                return this.View("Home");
            }

            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse IndexFull()
        {
            return this.Index();
        }
    }
}
