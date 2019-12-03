namespace Cinema.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Seat
    {
        public int Id { get; set; }

        [Required]
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
