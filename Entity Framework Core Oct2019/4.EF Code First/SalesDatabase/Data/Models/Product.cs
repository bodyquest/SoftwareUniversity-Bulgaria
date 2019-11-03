namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public Product()
        {
            this.Description = "No description";
        }

        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(50)] 
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }

        public ICollection<Sale> Sales { get; set; }  = new HashSet<Sale>();
    }
}
