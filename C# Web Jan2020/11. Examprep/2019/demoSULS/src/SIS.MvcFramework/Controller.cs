using System.IO;    
using System.Runtime.CompilerServices;

using SIS.HTTP;
using SIS.HTTP.Response;

namespace SIS.MvcFramework
{
    public abstract class Controller
    {
        protected HttpResponse View([CallerMemberName]string viewName = null)
        {
            var layout = File.ReadAllText("Views/Shared/_Layout.html");
            var controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            var html = File.ReadAllText("Views/" + controllerName + "/" + viewName + ".html");
            var bodyWithLayout = layout.Replace("@RenderBody()", html);

            return new HtmlResponse(bodyWithLayout);
        }
    }
}
