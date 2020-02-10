namespace ChushkaWebPREP.ViewModels.Products
{
    using ChushkaWebPREP.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EditProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductType Type { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
