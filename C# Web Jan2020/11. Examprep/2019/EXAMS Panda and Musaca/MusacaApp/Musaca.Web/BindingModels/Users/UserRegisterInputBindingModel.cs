namespace Musaca.Web.BindingModels.Users
{
    using SIS.MvcFramework.Attributes.Validation;

    public class UserRegisterInputBindingModel
    {
        private const string UsernameErrorMessage = "Invalid username length! Must be between 5 and 20 symbols!";

        private const string EmailErrorMessage = "Email must be between 5 and 20 symbols!";

        private const string PasswordErrorMessage = "Invalid password length!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        [PasswordSis(nameof(ConfirmPassword))]
        public string Password { get; set; }

        [RequiredSis(PasswordErrorMessage)]
        public string ConfirmPassword { get; set; }

        [RequiredSis]
        [EmailSis]
        [StringLengthSis(5, 20, EmailErrorMessage)]
        public string Email { get; set; }
    }
}
