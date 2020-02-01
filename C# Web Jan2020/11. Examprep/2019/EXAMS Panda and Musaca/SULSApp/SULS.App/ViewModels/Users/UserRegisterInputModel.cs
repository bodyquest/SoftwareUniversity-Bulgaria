namespace SULS.App.ViewModels.Users
{
    using SIS.MvcFramework.Attributes.Validation;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserRegisterInputModel
    {
        private const string UsernameErrorMessage = "Invalid username length! Must be between 5 and 20 symbols!";

        private const string PasswordErrorMessage = "Invalid password length!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        [EmailSis]
        public string Email { get; set; }

        [RequiredSis]
        [PasswordSis(nameof(ConfirmPassword))]
        public string Password { get; set; }

        [RequiredSis(PasswordErrorMessage)]
        public string ConfirmPassword { get; set; }
    }
}
