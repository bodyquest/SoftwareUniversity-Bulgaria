namespace Spice.Services.Admin.Models.MenuItems
{
    using Spice.Models;
    using Spice.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminMenuItemVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Spicyness { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Display(Name = "Subcategory")]
        public int SubcategoryId { get; set; }

        public virtual Subcategory Subcategory { get; set; }

        public double Price { get; set; }
    }
}
