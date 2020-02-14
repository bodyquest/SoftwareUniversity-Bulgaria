namespace Andreys.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreateProductInputViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
