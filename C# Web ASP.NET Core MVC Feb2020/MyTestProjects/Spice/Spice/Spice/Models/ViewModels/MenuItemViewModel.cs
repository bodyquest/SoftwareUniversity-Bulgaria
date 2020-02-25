namespace Spice.Models.ViewModels
{
    using Spice.Services.Admin.Models;
    using System.Collections.Generic;

    public class MenuItemViewModel
    {
        public MenuItem MenuItem { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Subcategory> Subcategories { get; set; }

    }
}
