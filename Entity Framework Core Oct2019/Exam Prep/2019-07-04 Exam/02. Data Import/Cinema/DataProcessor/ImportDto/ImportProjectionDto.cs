namespace Cinema.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    [XmlType("Projection")]
    public class ImportProjectionDto
    {
        [Required]
        [XmlElement(ElementName = "MovieId")]
        public int MovieId { get; set; }

        [Required]
        [XmlElement(ElementName = "HallId")]
        public int HallId { get; set; }

        [Required]
        [XmlElement(ElementName = "DateTime")]
        public string DateTime { get; set; }
    }
}
