using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.ViewModels.Users
{
    public class UserLoginInputModel
    {
        private const string UsernameErrorMessage = "Invalid username length! Must be between 5 and 20 symbols!";

        private const string PasswordErrorMessage = "Invalid password length!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }

        [RequiredSis(PasswordErrorMessage)]
        public string Password { get; set; }
    }
}
