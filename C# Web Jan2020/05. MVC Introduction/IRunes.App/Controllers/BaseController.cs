namespace IRunes.App.Controllers
{
    using System.IO;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using IRunes.Models;
    using SIS.HTTP.Requests;
    using SIS.MvcFramework.Result;
    using SIS.HTTP.Responses;

    public abstract class BaseController
    {
        protected Dictionary<string, object> ViewData;

        protected BaseController()
        {
            this.ViewData = new Dictionary<string, object>();
        }

        private string ParseTemplate(string viewContent)
        {
            foreach (var param in this.ViewData)
            {
                viewContent = viewContent.Replace($"@Model.{param.Key}", param.Value.ToString());
            }

            return viewContent;
        }

        protected void SignIn(IHttpRequest httpRequest, User user)
        {
            httpRequest.Session.AddParameter("id", user.Id);
            httpRequest.Session.AddParameter("username", user.Username);
            httpRequest.Session.AddParameter("email", user.Email);
        }

        protected void SignOut(IHttpRequest httpRequest)
        {
            httpRequest.Session.ClearParameters();
        }

        protected bool IsLoggedIn(IHttpRequest request)
        {
            return request.Session.ContainsParameter("username");
        }

        protected IHttpResponse View([CallerMemberName] string view = null)
        {
            string controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            string viewName = view;

            string viewContent = File.ReadAllText("Views/" + controllerName + "/" + viewName + ".html");

            viewContent = this.ParseTemplate(viewContent);
            HtmlResult htmlResult = new HtmlResult(viewContent, SIS.HTTP.Enums.HttpResponseStatusCode.Ok);

            return htmlResult;
        }

        protected IHttpResponse Redirect(string url)
        {
            return new RedirectResult(url);
        }
    }
}
