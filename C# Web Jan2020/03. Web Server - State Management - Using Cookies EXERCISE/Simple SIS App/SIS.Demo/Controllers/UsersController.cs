namespace SIS.Demo.Controllers
{
    using System.Linq;

    using SIS.Data;
    using SIS.Models;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;

    public class UsersController : BaseController
    {
        public IHttpResponse Login(IHttpRequest httpRequest)
        {
            return this.View();
        }

        public IHttpResponse LoginConfirm(IHttpRequest httpRequest)
        {
            using (var context = new DemoDbContext())
            {
                string username = httpRequest.FormData["username"].ToString();
                string password = httpRequest.FormData["password"].ToString();

                User userFromDb = context.Users.SingleOrDefault(user => user.Username == username && user.Password == password);

                if (userFromDb == null)
                {
                    return this.Redirect("/login");
                }

                httpRequest.Session.AddParameter("username", userFromDb.Username);
            }

            return this.Redirect("/home");
        }

        public IHttpResponse Register(IHttpRequest httpRequest)
        {
            return this.View();
        }

        public IHttpResponse RegisterConfirm(IHttpRequest httpRequest)
        {
            using (var context = new DemoDbContext())
            {
                string username = httpRequest.FormData["username"].ToString();
                string password = httpRequest.FormData["password"].ToString();
                string confirmPassowrd = httpRequest.FormData["confirmPassword"].ToString();

                if (password != confirmPassowrd)
                {
                    return this.Redirect("/register");
                }

                User user = new User()
                {
                    Username = username,
                    Password = password
                };

                context.Users.Add(user);
                context.SaveChanges();

                return this.Redirect("/login");
            }
        }

        public IHttpResponse Logout(IHttpRequest httpRequest)
        {
            httpRequest.Session.ClearParameters();

            return this.Redirect("/");
        }
    }
}
