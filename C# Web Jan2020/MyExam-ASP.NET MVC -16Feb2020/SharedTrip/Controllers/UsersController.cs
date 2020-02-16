namespace SharedTrip.Controllers
{
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Users;
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
                return this.Redirect("/Users/Register");
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            if (this.userService.EmailExists(model.Email))
            {
                return this.Redirect("/Users/Register");
            }

            if (this.userService.UsernameExists(model.Username))
            {
                return this.Redirect("/Users/Register");
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
