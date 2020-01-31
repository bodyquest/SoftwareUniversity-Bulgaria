namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using System.IO;
    using SIS.HTTP.Response;

    public class StaticFilesController
    {
        public HttpResponse Bootstrap(HttpRequest request)
        {
            return new FileResponse(File.ReadAllBytes("wwwroot/css/bootstrap.min.css"), "text/css");
        }

        public HttpResponse Site(HttpRequest request)
        {
            return new FileResponse(File.ReadAllBytes("wwwroot/css/site.css"), "text/css");
        }

        public HttpResponse Reset(HttpRequest request)
        {
            return new FileResponse(File.ReadAllBytes("wwwroot/css/reset.css"), "text/css");
        }
    }
}
