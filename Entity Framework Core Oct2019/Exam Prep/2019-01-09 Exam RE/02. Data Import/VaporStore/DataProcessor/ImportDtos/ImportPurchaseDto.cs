namespace VaporStore.DataProcessor.ImportDtos
{
    using System.Xml.Serialization;     
    using System.ComponentModel.DataAnnotations;

    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [XmlAttribute(AttributeName ="title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "Key")]
        [Required]
        [RegularExpression("^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
        public string Key { get; set; }

        [XmlElement(ElementName = "Card")]
        public string Card { get; set; }

        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }
    }
}
