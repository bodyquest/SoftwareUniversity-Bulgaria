namespace SIS.HTTP.Cookies
{
    using System.Collections.Generic;

    public interface IHttpCookieCollection : IEnumerable<HttpCookie>
    {
        void AddCookie(HttpCookie httpCookie);

        bool ContainsCookie(string key);

        HttpCookie GetCookie(string key);

        bool HasCookies();
    }
}
