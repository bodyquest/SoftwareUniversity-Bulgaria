namespace MishMashWebPREP.Controllers
{
    using MishMashWebPREP.Models;
    using MishMashWebPREP.Models.Enums;
    using MishMashWebPREP.ViewModels.Users;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class UsersController : BaseController
    {
        private readonly IHashService hashService;

        public UsersController(IHashService hashService)
        {
            this.hashService = hashService;
        }

        public IHttpResponse Login()
        {
            if (this.User.IsLoggedIn)
            {
                return this.Redirect("/");
            }

            return this.View("/Users/Login");
        }

       [HttpPost("/Users/Login")]
        public IHttpResponse Login(LoginInputViewModel model)
        {
            var hashedPassword = this.hashService.Hash(model.Password);

            var user = this.Context.Users.FirstOrDefault(x => x.Username == model.Username && x.Password == hashedPassword);

            if (user == null)
            {
                return this.BadRequestErrorWithView("Invalid Username or Password.");
            }

            var mvcUser = new MvcUserInfo
            {
                Username = model.Username,
                Info = user.Username,
                Role = user.Role.ToString()
            };

            var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);

            var cookie = new HttpCookie(".auth-mishmash", cookieContent);

            this.Response.Cookies.Add(cookie);

            return this.View();
        }

        public IHttpResponse Register()
        {
            if (this.User.IsLoggedIn)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public IHttpResponse Register(RegisterInputViewModel model)
        {
            var role = Role.User;
            if (!this.Context.Users.Any())
            {
                role = Role.Admin;
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.hashService.Hash(model.Password),
                Role = role
            };

            this.Context.Users.Add(user);
            this.Context.SaveChanges();

            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public IHttpResponse Logout()
        {
            if (!this.Request.Cookies.ContainsCookie(".auth-mishmash"))
            {
                return this.Redirect("/");
            }

            var cookie = this.Request.Cookies.GetCookie(".auth-mishmash");
            cookie.Delete();
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }
    }
}
