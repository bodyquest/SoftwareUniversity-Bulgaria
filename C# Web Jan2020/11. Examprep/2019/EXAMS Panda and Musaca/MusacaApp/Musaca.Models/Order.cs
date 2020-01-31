namespace Musaca.Models
{
    using System;
    using System.Collections.Generic;

    using Musaca.Models.Enums;

    public class Order
    {
        public Order()
        {
            this.Products = new List<OrderProduct>();
        }

        public int Id { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Active;

        public DateTime IssuedOn { get; set; }

        public List<OrderProduct> Products { get; set; }

        public string CashierId { get; set; }
        public User Cashier { get; set; }
    }
}
