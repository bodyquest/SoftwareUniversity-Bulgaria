namespace Andreys.Controllers
{
    using Andreys.Services;
    using Andreys.ViewModels.Users;
    using SIS.HTTP;
    using SIS.MvcFramework;

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

        [HttpPost("/Users/Login")]
        public HttpResponse Login(LoginInputViewModel model)
        {
            var userId = this.userService.GetUserIdOrNull(model.Username, model.Password);
            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/");
            }

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost("/Users/Register")]
        public HttpResponse Register(RegisterInputViewModel model)
        {
            // Email empty; Email exists
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                return this.Error("Email cannot be empty.");
            }

            if (this.userService.EmailExists(model.Email))
            {
                return this.Error("Email already in use.");
            }

            // Username string constraints; Username exists
            if (model.Username.Length < 4 || model.Username.Length > 10)
            {
                return this.Error("Username must be between 4 and 10 characters long.");
            }

            if (this.userService.UsernameExists(model.Username))
            {
                return this.Error("Username already in use.");
            }

            // Password string constraints; Passwords not matching
            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Error("Password must be between 6 and 20 characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("Passwords do not match.");
            }

            this.userService.Register(model.Username, model.Email, model.Password);

            return this.Redirect("/Users/Login");
        }

        [HttpGet("/Users/Logout")]
        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
