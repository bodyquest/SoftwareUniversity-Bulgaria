namespace FastFood.Web.ViewModels.Orders
{
    using FastFood.Models;
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<string> Items { get; set; }

        public List<string> Employees { get; set; }
    }
}
