namespace SIS.HTTP.Requests
{
    using System.Collections.Generic;

    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Sessions;
    using SIS.HTTP.Cookies.Contracts;

    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        Dictionary<string, ISet<string>> FormData { get; }

        Dictionary<string, ISet<string>> QueryData { get; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        HttpRequestMethod RequestMethod { get; }

        IHttpSession Session { get; set; }
    }
}
