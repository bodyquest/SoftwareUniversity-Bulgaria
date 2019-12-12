namespace Stations.DataProcessor.Dto.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportStationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Town { get; set; }
    }
}
