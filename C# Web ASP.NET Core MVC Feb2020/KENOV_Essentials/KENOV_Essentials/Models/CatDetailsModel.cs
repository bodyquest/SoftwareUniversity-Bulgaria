namespace KENOV_Essentials.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class CatDetailsModel : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Name must be bellow 10 characters long.")]
        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id == 5 && Name == "Dari")
            {
                yield return new ValidationResult("Sorry, Id cannot be 5 if your name is Dari");
            }
            else if (Id == 6)
            {
                yield return new ValidationResult("Sorry, Id cannot be 6.");
            }
        }
    }
}
