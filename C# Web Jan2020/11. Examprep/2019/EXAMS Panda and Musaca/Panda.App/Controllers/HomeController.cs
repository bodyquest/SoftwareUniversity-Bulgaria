namespace Panda.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Attributes;

    public class HomeController : Controller
    {
        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        // /Home/Index
        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                return this.View("IndexLoggedIn");
            }

            return this.View();
        }
    }
}
