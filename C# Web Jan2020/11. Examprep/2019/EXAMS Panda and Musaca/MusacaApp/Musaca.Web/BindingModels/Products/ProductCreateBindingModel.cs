namespace Musaca.Web.BindingModels.Products
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using SIS.MvcFramework.Attributes.Validation;

    public class ProductCreateBindingModel
    {
        private const string NameErrorMessage = "Product name must be between 5 and 20 symbols long.";
        private const string PriceErrorMessage = "Product price must be greater than or equal to 0.01.";

        [RequiredSis]
        [StringLengthSis(5, 20, NameErrorMessage)]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(0.01D, 10000D, PriceErrorMessage)]
        public double Price { get; set; }
    }
}
