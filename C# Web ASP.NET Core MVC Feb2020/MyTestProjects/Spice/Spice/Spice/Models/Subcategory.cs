namespace Spice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Subcategory
    {
        public int Id { get; set; }

        [Display(Name = "Subcategory Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
