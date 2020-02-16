namespace SharedTrip.Controllers
{
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Users;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel model)
        {
            var userId = this.userService.GetUserId(model.Username, model.Password);

            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/");
            }

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                return this.Error("Email cannot be empty!");
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Error("Password must be between 6 and 20 characters long.");
            }

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                return this.Error("Username must be between 5 and 20 characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("Passwords do not match.");
            }

            if (this.userService.EmailExists(model.Email))
            {
                return this.Error("Email is already in use.");
            }

            if (this.userService.UsernameExists(model.Username))
            {
                return this.Error("Username is already in use.");
            }

            this.userService.Register(model.Username, model.Email, model.Password);

            return this.Redirect("/Users/Login");
        }


        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
