namespace SharedTrip.Services
{
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ITripService
    {
        string Create(string strartingPoint, string endPoint, string departureTime, string carImage, int seats, string description);

        AllTripsViewModel GetAll();

        TripDetailsViewModel GetDetails(string id);
    }
}
