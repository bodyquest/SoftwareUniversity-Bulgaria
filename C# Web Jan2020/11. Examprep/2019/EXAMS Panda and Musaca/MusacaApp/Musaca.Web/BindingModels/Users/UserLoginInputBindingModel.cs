namespace Musaca.Web.BindingModels.Users
{
    using SIS.MvcFramework.Attributes.Validation;

    public class UserLoginInputBindingModel
    {
        private const string ErrorMessage = "Invalid username or password!";
        private const string UsernameErrorMessage = "Invalid username length! Must be between 5 and 20 symbols!";

        [RequiredSis(ErrorMessage)]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }

        [RequiredSis(ErrorMessage)]
        public string Password { get; set; }
    }
}
