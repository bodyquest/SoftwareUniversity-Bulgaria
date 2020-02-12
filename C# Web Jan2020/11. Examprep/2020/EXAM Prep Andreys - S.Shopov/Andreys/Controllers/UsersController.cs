namespace Andreys.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UsersController : Controller
    {
        public UsersController()
        {

        }

        [HttpGet("/Users/Login")]
        public HttpResponse Login()
        {


            return this.View();
        }

        [HttpPost("/Users/Login")]
        public HttpResponse Login(int id)  // add ViewModel
        {


            return this.Redirect("/");
        }

        [HttpGet("/Users/Register")]
        public HttpResponse Register()
        {


            return this.View();
        }

        [HttpPost("/Users/Register")]
        public HttpResponse Register(int id) //add View Model
        {


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
