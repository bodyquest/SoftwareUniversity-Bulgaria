using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responses;

namespace SIS.MvcFramework.Result
{
    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location) : base(HttpResponseStatusCode.SeeOther)
        {
            this.Headers.AddHeader(new HttpHeader("Location", location));
        }
    }
}
