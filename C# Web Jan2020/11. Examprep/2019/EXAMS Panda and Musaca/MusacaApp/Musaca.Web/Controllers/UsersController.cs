namespace Musaca.Web.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using Musaca.Models;
    using Musaca.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Mapping;
    using SIS.MvcFramework.Attributes;
    using Musaca.Web.ViewModels.Users;
    using Musaca.Web.ViewModels.Orders;
    using Musaca.Web.BindingModels.Users;
    using SIS.MvcFramework.Attributes.Security;

    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IOrderService orderService;

        public UsersController(IUserService userService, IOrderService orderService)
        {
            this.userService = userService;
            this.orderService = orderService;
        }

        public IActionResult Login()
        {
            return this.View();
        }
        
        [HttpPost]
        public IActionResult Login(UserLoginInputBindingModel model)
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
        public IActionResult Register(UserRegisterInputBindingModel model)
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
            this.orderService.CreateOrder(new Order { CashierId = userId});

            //this.SignIn(userId, model.Username, model.Email);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Profile()
        {
            // /Users/Profile
            UserProfileViewModel userProfileViewModel = new UserProfileViewModel();
            List<Order> ordersFromDb = this.orderService.GetAllCompletedOrdersByCashierId(this.User.Id);


            userProfileViewModel.Orders = ordersFromDb
                .To<OrderProfileViewModel>()
                .ToList();

            foreach (var order in userProfileViewModel.Orders)
            {
                order.CashierName = this.User.Username;
                order.TotalPrice = ordersFromDb
                    .Where(x => x.Id.ToString() == order.Id)
                    .SelectMany(x => x.Products)
                    .Sum(x => x.Product.Price).ToString();

                order.IssuedOnDate = ordersFromDb
                    .SingleOrDefault(x => x.Id.ToString() == order.Id)
                    .IssuedOn.ToString("dd/MM/yyyy");
            }

            return this.View(userProfileViewModel);
        }


        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
