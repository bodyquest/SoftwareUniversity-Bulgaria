namespace PetClinic.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ExportprocedureDto
    {
        [XmlElement("Passport")]
        public string Passport { get; set; }

        [XmlElement("OwnerNumber")]
        public string OwnerNumber { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public AnimalAidDto[] AnimalAids { get; set; }

        [XmlElement("TotalPrice")]
        public string TotalPrice { get; set; }
    }

    [XmlType("AnimalAid")]
    public class AnimalAidDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]
        public string Price { get; set; }
    }
}
