namespace Musaca.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class OrderProduct
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
