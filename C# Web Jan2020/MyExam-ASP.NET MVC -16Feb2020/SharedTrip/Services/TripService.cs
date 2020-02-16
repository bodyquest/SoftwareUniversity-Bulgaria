namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Globalization;
    using System.Linq;

    public class TripService : ITripService
    {
        private readonly ApplicationDbContext context;

        public TripService(ApplicationDbContext context)
        {
            this.context = context;
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
                    Seats = x.Seats,
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
                    Seats = x.Seats,
                    Description = x.Description,
                    ImagePath = x.ImagePath
                })
                .FirstOrDefault(x => x.Id == id);

            return model;
        }
    }
}
