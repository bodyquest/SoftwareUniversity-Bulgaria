namespace Demo.App
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;

    public class HomeController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            string content = "<h1>Hello M@#% F@$?a!</h1>";

            return new HtmlResult(content, HttpResponseStatusCode.OK);
        }
    }
}
