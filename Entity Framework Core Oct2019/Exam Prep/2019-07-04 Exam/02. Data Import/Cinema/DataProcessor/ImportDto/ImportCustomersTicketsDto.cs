namespace Cinema.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    [XmlType("Customer")]
    public class ImportCustomersTicketsDto
    {
        [Required]
        [XmlElement("FirstName")]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [XmlElement("LastName")]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [XmlElement("Age")]
        [Range(12, 110)]
        public int Age { get; set; }

        [Required]
        [XmlElement("Balance")]
        [Range(typeof(decimal), "0.01", "10000000")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public TicketDto[] Tickets { get; set; }
    }

    [XmlType("Ticket")]
    public class TicketDto
    {
        [Required]
        [XmlElement("Price")]
        [Range(typeof(decimal), "0.01", "10000")]
        public decimal Price { get; set; }

        [Required]
        [XmlElement("ProjectionId")]
        public int ProjectionId { get; set; }
    }
}
