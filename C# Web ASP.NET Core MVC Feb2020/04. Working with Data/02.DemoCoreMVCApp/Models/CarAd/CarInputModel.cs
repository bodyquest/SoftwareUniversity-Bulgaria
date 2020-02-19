namespace _02.DemoCoreMVCApp.Models.CarAd
{
    using _02.DemoCoreMVCApp.ModelBinders;
    using _02.DemoCoreMVCApp.ValidationAttributes;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarBrandAndModel : IValidatableObject
    {
        [Required]
        [MinLength(2)]
        public string Brand { get; set; }

        [Required]
        [StringLength(30), MinLength(2)]
        public string Model { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Brand == "Audi" && !this.Model.StartsWith("Q") && !this.Model.StartsWith("A"))
            {
                yield return new ValidationResult("Invalid Audi model");
            }
        }
    }

    public class CarInputModel
    {
        [Required(ErrorMessage = "Field is required")]
        [Range(1, 10, ErrorMessage = "Please select a valid Type")]
        public CarType Type { get; set; }

        public CarBrandAndModel Vehicle { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Minimum length is 10 characters.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.Date)]
        //[ModelBinder(typeof(DateTimeToYearModelBinder))]
        [BeforeCurrentYear(1900)]
        public int Year { get; set; }

        //public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        public byte[] Image { get; set; }

    }

    public enum CarType
    {
        Sedan = 1,
        SUV = 2, 
        Combi = 3,
        Cabrio =4
    }
}
