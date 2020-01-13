namespace SIS.MvcFramework.Result
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Responses;

    public abstract class ActionResult : HttpResponse
    {
        protected ActionResult(HttpResponseStatusCode httpResponseStatusCode) : base(httpResponseStatusCode)
        {
        }
    }
}
