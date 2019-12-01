namespace FastFood.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Order")]
    public class ImportOrderDto
    {
        [Required]
        [XmlElement(ElementName = "Customer")]
        public string Customer { get; set; }

        [XmlElement(ElementName = "Employee")]
        public string Employee { get; set; }

        [Required]
        [XmlElement(ElementName = "DateTime")]
        public string DateTime { get; set; }

        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }

        [XmlArray("Items")]
        public ItemDto[] ItemDtos { get; set; }
    }

    [XmlType("Item")]
    public class ItemDto
    {
        [Required]
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [XmlElement(ElementName = "Quantity")]
        public int Quantity { get; set; }
    }
}
