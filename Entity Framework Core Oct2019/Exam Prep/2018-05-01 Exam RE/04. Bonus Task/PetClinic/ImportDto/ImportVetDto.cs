namespace PetClinic.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    [XmlType("Vet")]
    public class ImportVetDto
    {
        [Required]
        [XmlElement("Name")]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [XmlElement("Profession")]
        [StringLength(50, MinimumLength = 3)]
        public string Profession { get; set; }

        [Required]
        [XmlElement("Age")]
        [Range(22, 65)]
        public int Age { get; set; }

        [Required]
        [XmlElement("PhoneNumber")]
        [RegularExpression("^[0][0-9]{9}$|^\\+359[0-9]{9}$")]
        public string PhoneNumber { get; set; }
    }
}
