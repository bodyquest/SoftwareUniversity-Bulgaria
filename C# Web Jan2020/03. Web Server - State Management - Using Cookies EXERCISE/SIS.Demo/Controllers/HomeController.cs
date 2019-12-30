namespace SIS.Demo.Controllers
{
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;

    public class HomeController : BaseController
    {
        public IHttpResponse Home(IHttpRequest httpRequest)
        {
            this.HttpRequest = httpRequest;
            return this.View();
        }

        public IHttpResponse Login(IHttpRequest httpRequest)
        {
            httpRequest.Session.AddParameter("username", "dari");

            return this.Redirect("/");
        }

        public IHttpResponse Logout(IHttpRequest httpRequest)
        {
            httpRequest.Session.ClearParameters();

            return this.Redirect("/");
        }
    }
}
