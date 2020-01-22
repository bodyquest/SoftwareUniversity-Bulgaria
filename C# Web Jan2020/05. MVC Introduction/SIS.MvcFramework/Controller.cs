namespace SIS.MvcFramework
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using SIS.HTTP.Requests;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Identity;
    using SIS.MvcFramework.Extensions;
    using SIS.MvcFramework.ViewEngine;

    public abstract class Controller
    {
        private IViewEngine viewEngine = new SisViewEngine();

        protected Dictionary<string, object> ViewData;

        protected Controller()
        {
            ViewData = new Dictionary<string, object>();
        }

        //TODO: Refactor
        public Principal User => 
            this.Request.Session.ContainsParameter("principal")
            ? (Principal)this.Request.Session.GetParameter("principal")
            : null;

        public IHttpRequest Request { get; set; }

        #region
        //private string ParseTemplate(string viewContent)
        //{
        //    foreach (var param in ViewData)
        //    {
        //        viewContent = viewContent.Replace($"@Model.{param.Key}", param.Value.ToString());
        //    }

        //    return viewContent;
        //}
        #endregion

        protected bool IsLoggedIn()
        {
            return this.Request.Session.ContainsParameter("principal");
        }

        protected void SignIn(string id, string username, string email)
        {
            this.Request.Session.AddParameter("principal", new Principal 
            { 
                Id = id,
                Username = username,
                Email = email
            });
        }

        protected void SignOut()
        {
            this.Request.Session.ClearParameters();
        }

        protected ActionResult View ([CallerMemberName] string view = null)
        {
            return this.View<object>(null, view);
        }

        protected ActionResult View<T> (T model = null , [CallerMemberName] string view = null) where T : class
        {
            //TODO: Support for layout 
            string controllerName = GetType().Name.Replace("Controller", string.Empty);
            string viewName = view;

            //1. Parse the view
            string viewContent = System.IO.File.ReadAllText("Views/" + controllerName + "/" + viewName + ".html");
            viewContent = this.viewEngine.GetHtml(viewContent, model);

            //2. Parse the layout and include the view instead of @RenderBody()
            string layoutContent = System.IO.File.ReadAllText("Views/_Layout.html");
            layoutContent = this.viewEngine.GetHtml(layoutContent, model);
            layoutContent = layoutContent.Replace("@RenderBody()", viewContent);

            //3. Return the html result with layoutContent
            HtmlResult htmlResult = new HtmlResult(layoutContent);
            return htmlResult;
        }

        protected ActionResult Redirect(string url)
        {
            return new RedirectResult(url);
        }

        protected ActionResult Xml(object obj)
        {
            return new XmlResult(obj.ToXml());
        }

        protected ActionResult Json(object obj)
        {
            return new JsonResult(obj.ToJson());
        }

        protected ActionResult File(byte[] fileContent)
        {
            return new FileResult(fileContent);
        }

        protected ActionResult NotFound(string message = "")
        {
            return new NotFoundResult(message);
        }
    }
}
