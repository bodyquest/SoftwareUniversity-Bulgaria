using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stations.Models
{
    public class Station
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)] //Is Unique
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Town { get; set; }

        public ICollection<Trip> TripsTo { get; set; } = new HashSet<Trip>();
        public ICollection<Trip> TripsFrom { get; set; } = new HashSet<Trip>();
    }
}
