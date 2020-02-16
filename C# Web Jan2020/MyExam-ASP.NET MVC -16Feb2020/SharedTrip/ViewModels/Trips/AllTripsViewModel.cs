namespace SharedTrip.ViewModels.Trips
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AllTripsViewModel
    {
        public IEnumerable<TripListDetailsViewModel> TripList { get; set; }
    }
}
