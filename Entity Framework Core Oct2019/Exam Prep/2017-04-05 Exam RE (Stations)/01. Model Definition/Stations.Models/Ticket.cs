namespace Stations.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ticket
    {
        public int Id { get; set; }

        [Range(0, double.MaxValue), Required]
        public decimal Price { get; set; }

        [MaxLength(8), Required]
        [RegularExpression(@"^[A-Z]{2}\d{1,6}$")]
        public string SeatingPlace { get; set; }

        [ForeignKey(nameof(Trip)), Required]
        public int TripId { get; set; }
        public Trip Trip { get; set; }

        [ForeignKey(nameof(CustomerCard))]
        public int? CustomerCardId { get; set; }
        public CustomerCard CustomerCard { get; set; }
    }
}
