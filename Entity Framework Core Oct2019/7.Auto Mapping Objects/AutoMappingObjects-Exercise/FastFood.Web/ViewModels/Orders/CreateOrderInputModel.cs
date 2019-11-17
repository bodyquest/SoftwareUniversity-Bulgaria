namespace FastFood.Web.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class CreateOrderInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Customer { get; set; }

        public string ItemName { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }

        public string OrderType { get; set; }
    }
}
