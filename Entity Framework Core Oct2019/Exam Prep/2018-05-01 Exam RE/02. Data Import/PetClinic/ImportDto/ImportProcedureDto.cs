using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.ImportDto
{
    [XmlType("Procedure")]
    public class ImportProcedureDto
    {
        [XmlElement("Vet")]
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string VetName { get; set; }

        [XmlElement("Animal")]
        [Required]
        [RegularExpression("^[A-Za-z]{7}[0-9]{3}$")]
        public string AnimalSerial { get; set; }

        [XmlElement("DateTime")]
        [Required]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public AnimalAidProcedure[] AnimalAids { get; set; }
    }

    [XmlType("AnimalAid")]
    public class AnimalAidProcedure
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
