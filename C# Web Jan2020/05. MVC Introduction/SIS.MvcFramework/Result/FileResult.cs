namespace SIS.MvcFramework.Result
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;

    public class FileResult : ActionResult
    {
        public FileResult(byte[]fileContent, HttpResponseStatusCode httpResponseStatusCode = HttpResponseStatusCode.Ok) : base(httpResponseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentLength, fileContent.Length.ToString()));
            this.Headers.AddHeader(new HttpHeader(HttpHeader.ContentDisposition, "attachment"));
            this.Content = fileContent;
        }
    }
}
