namespace SharedTrip.ViewModels.Trips
{
    using System.Collections.Generic;

    public class AllTripsViewModel
    {
        public IEnumerable<TripListDetailsViewModel> TripList { get; set; }
    }
}
