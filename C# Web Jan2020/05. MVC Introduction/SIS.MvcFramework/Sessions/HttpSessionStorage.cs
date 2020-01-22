namespace SIS.MvcFramework.Sessions
{
    using SIS.HTTP.Sessions;
    using System.Collections.Concurrent;

    public class HttpSessionStorage : IHttpSessionStorage
    {
        public const string SessionCookieKey = "SIS_ID";

        private readonly ConcurrentDictionary<string, IHttpSession> httpSessions;

        public HttpSessionStorage()
        {
            this.httpSessions = new ConcurrentDictionary<string, IHttpSession>();
        }

        public bool ContainsSession(string id)
        {
            return httpSessions.ContainsKey(id);
        }

        public IHttpSession GetSession(string id)
        {
            return httpSessions.GetOrAdd(id, _ => new HttpSession(id));
        }
    }
}
