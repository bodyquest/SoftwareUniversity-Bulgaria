﻿namespace SIS.HTTP.Responses
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Cookies.Contracts;

    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        void AddCookie(HttpCookie cookie);

        byte[] GetBytes();
    }
}
