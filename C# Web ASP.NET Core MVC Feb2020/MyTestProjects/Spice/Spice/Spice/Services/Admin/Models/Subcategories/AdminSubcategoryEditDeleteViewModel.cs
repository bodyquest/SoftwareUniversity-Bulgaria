namespace Spice.Services.Admin.Models
{
    using Spice.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminSubcategoryEditDeleteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Subcategory Name")]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
