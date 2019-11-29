namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class ExportPrisonerDto
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public EncryptedMessageDto[] EncryptedMessages { get; set; }
    }

    [XmlType("Message")]
    public class EncryptedMessageDto
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
