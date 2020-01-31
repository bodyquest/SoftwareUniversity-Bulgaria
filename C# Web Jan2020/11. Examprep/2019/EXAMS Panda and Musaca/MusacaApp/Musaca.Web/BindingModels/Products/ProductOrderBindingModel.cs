namespace Musaca.Web.BindingModels.Products
{
    using SIS.MvcFramework.Attributes.Validation;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProductOrderBindingModel
    {
        [RequiredSis]
        public string Product { get; set; }
    }
}
