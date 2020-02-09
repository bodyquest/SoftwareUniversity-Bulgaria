namespace ChushkaWebPREP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderedOn { get; set; } = DateTime.UtcNow;

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
