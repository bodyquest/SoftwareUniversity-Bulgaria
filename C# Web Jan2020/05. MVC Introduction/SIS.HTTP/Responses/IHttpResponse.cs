namespace SIS.HTTP.Responses
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Headers;

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
