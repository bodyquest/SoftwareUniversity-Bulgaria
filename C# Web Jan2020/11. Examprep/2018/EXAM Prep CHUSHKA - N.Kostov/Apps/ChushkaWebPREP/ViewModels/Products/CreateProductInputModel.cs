namespace ChushkaWebPREP.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CreateProductInputModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }
    }
}
