namespace Andreys.ViewModels.Products
{
    using Andreys.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProductDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public ProductCategory Category { get; set; }

        public Gender Gender { get; set; }
    }
}
