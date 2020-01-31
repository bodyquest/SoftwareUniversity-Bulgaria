namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View();
        }

        //[HttpPost]
        //public HttpResponse Login(HttpRequest request)
        //{
        //    var layout = File.ReadAllText("Views/Shared/_Layout.html");
        //    var html = File.ReadAllText("Views/Users/Login.html");
        //    var bodyWithLayout = layout.Replace("@RenderBody()", html);

        //    return new HtmlResponse(bodyWithLayout);
        //}

        public HttpResponse Register(HttpRequest request)
        {
            return this.View();
        }
    }
}
