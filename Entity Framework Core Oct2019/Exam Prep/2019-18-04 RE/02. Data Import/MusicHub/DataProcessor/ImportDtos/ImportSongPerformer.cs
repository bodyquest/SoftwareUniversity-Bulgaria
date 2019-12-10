namespace MusicHub.DataProcessor.ImportDtos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Performer")]
    public class ImportSongPerformer
    {
        [XmlElement("FirstName")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [XmlElement("Age")]
        [Required]
        [Range(18, 70)]
        public int Age { get; set; }

        [XmlElement("NetWorth")]
        [Required]
        [Range(typeof(decimal), "0", "1000000000000")]
        public decimal NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public SongDto[] PerformersSongs { get; set; }
    }

    [XmlType("Song")]
    public class SongDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
