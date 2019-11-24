namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "parts")]
    public class ImportPartsDto
    {
        [XmlElement(ElementName = "partId")]
        public ImportPartIdDto [] PartId { get; set; }
    }
}
