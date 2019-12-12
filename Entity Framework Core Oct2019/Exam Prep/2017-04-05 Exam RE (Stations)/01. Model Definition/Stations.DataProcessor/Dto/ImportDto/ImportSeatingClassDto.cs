namespace Stations.DataProcessor.Dto.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ImportSeatingClassDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Abbreviation { get; set; }
    }
}
