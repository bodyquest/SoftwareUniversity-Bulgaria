namespace Stations.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Stations.Models.Enums;

    public class Train
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public int TrainNumber { get; set; }

        public TrainType? Type { get; set; }

        public ICollection<TrainSeat> TrainSeats { get; set; } = new HashSet<TrainSeat>();
        public ICollection<Trip> Trips { get; set; } = new HashSet<Trip>();
    }
}
