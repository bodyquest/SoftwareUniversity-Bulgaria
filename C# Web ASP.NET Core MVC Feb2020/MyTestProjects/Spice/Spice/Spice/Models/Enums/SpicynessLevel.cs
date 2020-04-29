using System.ComponentModel.DataAnnotations;

namespace Spice.Models.Enums
{
    public enum SpicynessLevel
    {
        [Display(Name = "NA")]
        NA = 0,

        [Display(Name = "Not Spicy")]
        NotSpicy = 1,

        [Display(Name = "Spicy")]
        Spicy = 2,

        [Display(Name = "Super Ultra Spicy")]
        VerySpicy = 3
    }
}
