namespace VaporStore.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;

    public class CardsDto
    {
        [Required]
        [RegularExpression("^[0-9]{4}\\s+[0-9]{4}\\s+[0-9]{4}\\s+[0-9]{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}$")]
        public string CVC { get; set; }

        public string Type { get; set; }
    }
}
