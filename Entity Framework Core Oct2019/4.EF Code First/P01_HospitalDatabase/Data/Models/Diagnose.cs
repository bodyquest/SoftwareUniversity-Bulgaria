namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Diagnose
    {
        [Column("DiagnoseId")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Comments { get; set; }

        public int? PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
