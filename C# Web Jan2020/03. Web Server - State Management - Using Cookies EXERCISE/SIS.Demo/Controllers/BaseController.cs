namespace SIS.Demo.Controllers
{
    using System.IO;
    using System.Runtime.CompilerServices;

    using SIS.HTTP.Enums;
    using SIS.HTTP.Cookies;
    using SIS.WebServer.Results;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;

    public abstract class BaseController
    {
        protected IHttpRequest HttpRequest { get; set; }
        private bool IsLoggedIn()
        {
            return this.HttpRequest.Session.ContainsParameter("username");
        }

        private string ParseTemplate(string viewContent)
        {
            if (this.IsLoggedIn())
            {
                return viewContent.Replace("@Model.HelloMessage", $"Hello, {this.HttpRequest.Session.GetParameter("username")}");
            }
            else
            {
                return viewContent.Replace("@Model.HelloMessage", "Hello World from SIS.WebDar Server");
            }
        }

        public IHttpResponse View([CallerMemberName] string view = null)
        {
            string controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            string viewName = view;
            string viewContent = File.ReadAllText("Views/" + controllerName + "/" + viewName + ".html");

            viewContent = this.ParseTemplate(viewContent);

            HtmlResult htmlResult = new HtmlResult(viewContent, HttpResponseStatusCode.OK);

            htmlResult.Cookies.AddCookie(new HttpCookie("lang", "en"));

            return htmlResult;
        }

        public IHttpResponse Redirect(string url)
        {
            return new RedirectResult(url);
        }
    }
}
