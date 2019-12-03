namespace PetClinic.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportAnimalAidDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "1000000")]
        public decimal Price { get; set; }
    }
}
