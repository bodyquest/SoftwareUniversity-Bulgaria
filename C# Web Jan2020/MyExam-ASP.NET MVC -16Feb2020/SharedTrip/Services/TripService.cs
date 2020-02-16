namespace SharedTrip.Services
{
    using System;
    using System.Globalization;
    using System.Linq;

    using SharedTrip.Models;
    using SIS.MvcFramework;
    using SharedTrip.ViewModels.Trips;

    public class TripService : ITripService
    {
        private readonly ApplicationDbContext context;
        private readonly IUserService userService;

        public TripService(ApplicationDbContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        public bool AddUserToTrip(string userId, string tripId)
        {
            var trip = this.context.Trip.FirstOrDefault(x => x.Id == tripId);

            var userTripExist = this.context.UserTrips.FirstOrDefault(x => x.UserId == userId && x.TripId == trip.Id);

            if (userTripExist != null)
            {
                return false;
            }

            if (userTripExist == null && trip.Seats - trip.UserTrips.Count > 0)
            {
                var userTrip = new UserTrip
                {
                    TripId = tripId,
                    UserId = userId
                };

                trip.UserTrips.Add(userTrip);
                this.context.UserTrips.Add(userTrip);

                this.context.SaveChanges();

                return true;
            }

            return false;
        }

        public string Create(string strartingPoint, string endPoint, string departureTime, string carImage, int seats, string description)
        {
            var trip = new Trip
            {
                StartPoint = strartingPoint,
                EndPoint = endPoint,
                DepartureTime = DateTime.ParseExact(departureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = carImage,
                Seats = seats,
                Description = description
            };

            this.context.Trip.Add(trip);
            this.context.SaveChanges();

            return trip.Id;
        }
            
        public AllTripsViewModel GetAll()
        {
            var model = new AllTripsViewModel();
            model.TripList = this.context.Trip
                .Select(x => new TripListDetailsViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    SeatsAvailable = x.Seats - x.UserTrips.Count,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm")
                }).ToList();

            return model;
        }

        public TripDetailsViewModel GetDetails(string id)
        {
            var model = this.context.Trip
                .Select(x => new TripDetailsViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    SeatsAvailable = x.Seats - x.UserTrips.Count,
                    Description = x.Description,
                    ImagePath = x.ImagePath
                })
                .FirstOrDefault(x => x.Id == id);

            return model;
        }
    }
}
