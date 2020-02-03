namespace SULS.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using SULS.App.ViewModels.Users;
    using SULS.Services;

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
        public IActionResult Login(UserLoginInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            var user = this.userService.GetUserOrNull(inputModel.Username, inputModel.Password);

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
        public IActionResult Register(UserRegisterInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            var userId = this.userService.CreateUser(inputModel.Username, inputModel.Email, inputModel.Password);

            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
