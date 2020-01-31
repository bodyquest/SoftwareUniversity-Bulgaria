namespace Musaca.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using SIS.MvcFramework.Attributes.Validation;

    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();

        }

        public string Id { get; set; }

        public string Name { get; set; }


        public decimal Price { get; set; }
    }
}
