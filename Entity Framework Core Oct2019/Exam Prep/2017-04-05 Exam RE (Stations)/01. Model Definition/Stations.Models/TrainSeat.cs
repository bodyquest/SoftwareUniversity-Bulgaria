namespace Stations.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TrainSeat
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Train)), Required]
        public int TrainId { get; set; }
        public Train Train { get; set; }

        [ForeignKey(nameof(SeatingClass)), Required]
        public int SeatingClassId { get; set; }
        public SeatingClass SeatingClass { get; set; }

        [Range(0, int.MaxValue), Required]
        public int Quantity { get; set; }
    }
}
