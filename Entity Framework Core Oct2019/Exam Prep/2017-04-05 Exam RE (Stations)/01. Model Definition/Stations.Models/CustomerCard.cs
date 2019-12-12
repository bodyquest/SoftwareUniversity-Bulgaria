namespace Stations.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CustomerCard
    {
        public int Id { get; set; }

        [MaxLength(128), Required]
        public string Name { get; set; }

        [Range(0, 120)]
        public int? Age { get; set; }

        //Default Normal
        public CardType Type { get; set; }

        public ICollection<Ticket> BoughtTickets { get; set; } = new HashSet<Ticket>();
    }

    public enum CardType
    {
        Pupil = 0,
        Student = 1,
        Elder = 2,
        Debilitated = 3,
        Normal = 4
    }
}
