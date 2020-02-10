namespace ChushkaWebPREP.ViewModels.Orders
{
    using System.Collections.Generic;

    public class AllOrdersViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}
