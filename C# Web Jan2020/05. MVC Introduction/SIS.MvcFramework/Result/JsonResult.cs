namespace SIS.MvcFramework.Result
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;

    public class JsonResult : ActionResult
    {
        public JsonResult(string jsonContent, HttpResponseStatusCode httpResponseStatusCode = HttpResponseStatusCode.Ok) : base(httpResponseStatusCode)
        {
            //TODO: HttpResponse - the methods AddHeader ad AddCookie are obsolete in their implementation. The collections must be immutable and then those methods should be like this.Headers.AddHeader(new Header{"key", "value"});

            this.AddHeader(new HttpHeader(HttpHeader.ContentType, "application/json"));
            this.Content = Encoding.UTF8.GetBytes(jsonContent);
        }
    }
}
