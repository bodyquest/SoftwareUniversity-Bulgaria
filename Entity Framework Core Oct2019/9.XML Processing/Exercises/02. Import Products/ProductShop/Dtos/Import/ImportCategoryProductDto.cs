namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("CategoryProduct")]
    public class ImportCategoryProductDto
    {
        [XmlElement(ElementName = "CategoryId")]
        public int CategoryId { get; set; }

        [XmlElement(ElementName = "ProductId")]
        public int ProductId { get; set; }
    }
}
