namespace SharedTrip.ViewModels.Trips
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TripListDetailsViewModel
    {
        public string Id { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public string DepartureTime { get; set; }

        public int Seats { get; set; }

        public int SeatsAvailable { get; set; }
    }
}
