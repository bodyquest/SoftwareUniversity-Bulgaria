namespace Stations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Trip
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Station)), Required]
        public int OriginStationId { get; set; }
        public Station OriginStation { get; set; }

        [ForeignKey(nameof(Station)), Required]
        public int DestinationStationId { get; set; }
        public Station DestinationStation  { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }

        [ForeignKey(nameof(Train)), Required]
        public int TrainId { get; set; }
        public Train Train { get; set; }

        //Default: OnTime
        public TripStatus Status { get; set; }

        public TimeSpan? TimeDifference { get; set; }
    }

    public enum TripStatus
    {
        OnTime = 0,
        Delayed = 1,
        Early = 2
    }
}
