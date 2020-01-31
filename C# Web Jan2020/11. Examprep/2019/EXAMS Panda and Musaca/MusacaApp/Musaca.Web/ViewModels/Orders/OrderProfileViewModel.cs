namespace Musaca.Web.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OrderProfileViewModel
    {
        public string Id { get; set; }

        public string TotalPrice { get; set; }

        public string IssuedOnDate { get; set; }

        public string CashierName { get; set; }
    }
}
 