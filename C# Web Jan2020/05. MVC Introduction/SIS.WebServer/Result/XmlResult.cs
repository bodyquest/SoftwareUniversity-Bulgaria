namespace SIS.MvcFramework.Result
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class XmlResult : ActionResult
    {
        public XmlResult(string xmlContent, HttpResponseStatusCode httpResponseStatusCode = HttpResponseStatusCode.Ok) : base(httpResponseStatusCode)
        {
            //TODO HttpResponse - the methods AddHeader ad AddCookie are obsolete in their implementation. The collections must be immutable and then those methods should be like this.Headers.AddHeader(new Header{"key", "value"});

            this.AddHeader(new HttpHeader(HttpHeader.ContentType, "application/xml"));
            this.Content = Encoding.UTF8.GetBytes(xmlContent);
        }
    }
}
