namespace ChushkaWebPREP.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ChushkaWebPREP.Models;
    using ChushkaWebPREP.Models.Enums;
    using ChushkaWebPREP.ViewModels.Users;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Services;

    public class UsersController : BaseController
    {
        private readonly IHashService hashService;

        public UsersController(IHashService hashService)
        {
            this.hashService = hashService;
        }


        public IHttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Login(LoginInputModel model)
        {
            var hashedPasswprd = this.hashService.Hash(model.Password);

            var user = this.Context.Users.FirstOrDefault(x => x.Username == model.Username.Trim() && x.Password == hashedPasswprd);

            if (user == null)
            {
                
                return this.BadRequestErrorWithView("Invalid Username or Password.");
            }

            var mvcUser = new MvcUserInfo 
            { 
                Username = model.Username,
                Role = user.Role.ToString(),
                Info = user.Username
            };

            var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);

            var cookie = new HttpCookie(".auth-chushka", cookieContent);

            this.Response.Cookies.Add(cookie);

            return this.Redirect("/");
        }

        public IHttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Register(RegisterInputModel model)
        {
            if (String.IsNullOrWhiteSpace(model.Username))
            {
                return this.BadRequestErrorWithView("Please provide a Username.");
            }
            if (String.IsNullOrWhiteSpace(model.Email))
            {
                return this.BadRequestErrorWithView("Please provide an Email.");
            }
            if (this.Context.Users.Any(x=>x.Username == model.Username))
            {
                return this.BadRequestErrorWithView("Please provide different Username. This username is not available.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.BadRequestErrorWithView("Passwords don't match.");
            }

            var role = UserRole.Admin;
            if (!this.Context.Users.Any())
            {
                role = UserRole.Admin;
            }

            var user = new User
            {
                Username = model.Username.Trim(),
                Password = this.hashService.Hash(model.Password),
                FullName = model.FullName.Trim(),
                Email = model.Email.Trim(),
                Role = role 
            };

            this.Context.Users.Add(user);
            try
            {
                this.Context.SaveChanges();
            }
            catch (Exception e)
            {

                return this.BadRequestErrorWithView(e.Message);
            }

            return this.Redirect("/Users/Login");
        }

        public IHttpResponse Logout()
        {
            if (this.Request.Cookies.ContainsCookie(".auth-chushka"))
            {
                return this.Redirect("/");
            }

            var cookie = this.Request.Cookies.GetCookie(".auth-chushka");
            cookie.Delete();
            this.Response.Cookies.Add(cookie);

            return this.Redirect("/");
        }
    }
}
