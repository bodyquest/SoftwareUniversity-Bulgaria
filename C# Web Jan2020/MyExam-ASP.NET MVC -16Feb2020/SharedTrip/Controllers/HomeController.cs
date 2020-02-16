namespace SharedTrip.App.Controllers
{
    using SharedTrip.Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly ITripService tripService;

        public HomeController(ITripService tripService)
        {
            this.tripService = tripService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                
                var model = this.tripService.GetAll();

                return this.Redirect("/Trips/All");
            }

            return this.View();
        }
    }
}