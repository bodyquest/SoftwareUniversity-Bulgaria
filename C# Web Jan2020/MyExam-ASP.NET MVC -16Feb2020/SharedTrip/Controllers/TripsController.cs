namespace SharedTrip.Controllers
{
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Trips;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TripsController : Controller
    {
        private readonly ITripService tripService;

        public TripsController(ITripService tripService)
        {
            this.tripService = tripService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CreateTripInputModel model)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.IsUserLoggedIn())
            {
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                return this.View();
            }

            //TODO: regex match input?
            if (string.IsNullOrWhiteSpace(model.DepartureTime))
            {
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(model.Seats.ToString()) || (model.Seats < 2 || model.Seats > 6))
            {
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 80)
            {
                return this.View();
            }

            this.tripService.Create(model.StartPoint, model.EndPoint, model.DepartureTime, model.ImagePath, model.Seats, model.Description);
            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var model = this.tripService.GetDetails(id);

            return this.View(model);
        }

        public HttpResponse All()
        {
            if (this.IsUserLoggedIn())
            {
                var model = this.tripService.GetAll();

                return this.View(model,"/All");
            }

            return this.Redirect("/Users/Login");
        }
    }
}
