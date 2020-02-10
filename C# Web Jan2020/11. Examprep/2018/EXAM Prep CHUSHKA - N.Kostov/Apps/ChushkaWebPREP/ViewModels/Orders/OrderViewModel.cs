namespace ChushkaWebPREP.ViewModels.Orders
{
    using System;

    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTime OrderedOn { get; set; } = DateTime.UtcNow;

        public string ProductName { get; set; }

        public string Username { get; set; }
    }
}
