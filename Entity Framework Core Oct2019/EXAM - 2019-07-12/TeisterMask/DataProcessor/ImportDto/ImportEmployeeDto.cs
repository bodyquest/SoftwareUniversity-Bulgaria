namespace TeisterMask.DataProcessor.ImportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ImportEmployeeDto
    {
        [Required]
        //Check if this is true "^[A-Z0-9]{3,40}|[a-z0-9]{3,40}|[0-9]{3,40}$"
        //"[A-Za-z0-9]+"
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression("^[A-Z0-9]{3,40}|[a-z0-9]{3,40}|[0-9]{3,40}$")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        public List<int> Tasks { get; set; }
    }
}
