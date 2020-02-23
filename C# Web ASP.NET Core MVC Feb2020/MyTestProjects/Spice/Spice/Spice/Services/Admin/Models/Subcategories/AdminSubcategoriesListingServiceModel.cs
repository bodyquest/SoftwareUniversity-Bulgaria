namespace Spice.Services.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminSubcategoriesListingServiceModel
    {
        public int Id { get; set; }

        [Display(Name="Subcategory Name")]
        public string Name { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}
