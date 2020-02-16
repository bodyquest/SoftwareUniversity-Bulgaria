namespace SharedTrip.App.Controllers
{
    using SharedTrip.Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            return this.View();
        }

        [HttpGet("Home/Index")]
        public HttpResponse IndexFull()
        {
            return this.Index();
        }
    }
}