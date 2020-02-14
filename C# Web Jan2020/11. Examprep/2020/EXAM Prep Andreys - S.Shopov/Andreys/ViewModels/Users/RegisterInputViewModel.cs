namespace Andreys.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterInputViewModel
    {
        [Required]
        [MinLength(4), MaxLength(10)]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
