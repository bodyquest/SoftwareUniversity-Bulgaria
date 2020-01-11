namespace SIS.MvcFramework.Routing
{
    using System;

    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;

    public interface IServerRoutingTable
    {
        void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpResponse> func);

        bool Contains(HttpRequestMethod method, string path);

        Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod requestMethod, string path);
    }
}
