namespace Stations.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SeatingClass
    {
        public int Id { get; set; }

        [Required] //Is Unique
        [MaxLength(30)]
        public string Name { get; set; }

        [Required] //Is Unique
        [StringLength(2, MinimumLength = 2)]
        public string Abbreviation { get; set; }
    }
}
