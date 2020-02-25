using System.ComponentModel.DataAnnotations;

namespace Spice.Models.Enums
{
    public enum SpicynessLevel
    {
        [Display(Name = "NA")]
        NA = 0,

        [Display(Name = "NotSpicy")]
        NotSpicy = 1,

        [Display(Name = "Spicy")]
        Spicy = 2,

        [Display(Name = "VerySpicy")]
        VerySpicy = 3
    }
}
