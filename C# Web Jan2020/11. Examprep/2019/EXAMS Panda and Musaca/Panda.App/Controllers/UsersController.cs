namespace Panda.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Attributes;

    using Panda.Models;
    using Panda.Services;
    using Panda.App.ViewModels.Users;
    using SIS.MvcFramework.Attributes.Security;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Login()
        {
            return this.View();
        }
        
        [HttpPost]
        public IActionResult Login(UserLoginInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            var user = this.userService.GetUserOrNull(model.Username, model.Password);
            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(user.Id, user.Username, user.Email);

            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            User user = new User
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email
            };

            var userId = this.userService.CreateUser(model.Username, model.Email, model.Password);
            this.SignIn(userId, model.Username, model.Email);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
