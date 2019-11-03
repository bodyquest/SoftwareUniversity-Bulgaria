namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Visitation
    {
        [Column("VisitationId")]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(250)]
        public string Comments { get; set; }

        public int? PatientId { get; set; }

        public Patient Patient { get; set; }

    }
}
