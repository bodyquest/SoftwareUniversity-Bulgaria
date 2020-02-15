namespace MishMash.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UsersController : Controller
    {
        public HttpResponse Login()
        {

            return this.View("/Users/Login");
        }

        public HttpResponse Register()
        {

            return this.View("/Users/Register");
        }
    }
}
