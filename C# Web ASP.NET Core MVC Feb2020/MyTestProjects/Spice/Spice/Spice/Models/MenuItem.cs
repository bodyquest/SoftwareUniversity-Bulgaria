namespace Spice.Models
{
    using Spice.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

    public class MenuItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Spicyness { get; set; }

        public SpicynessLevel ESpicy { get; set; }

        public string Image { get; set; }


        [Display(Name ="Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }


        [Display(Name = "Subcategory")]
        public int SubcategoryId { get; set; }

        [ForeignKey("SubcategoryId")]
        public virtual Subcategory Subcategory { get; set; }


        [Range(1, int.MaxValue, ErrorMessage ="Price shoud be greater than ${1}")]
        public double Price { get; set; }
    }
}
