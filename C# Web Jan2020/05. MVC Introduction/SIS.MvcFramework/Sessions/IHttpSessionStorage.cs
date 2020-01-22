namespace SIS.MvcFramework.Sessions
{
    using SIS.HTTP.Sessions;

    public interface IHttpSessionStorage
    {
        IHttpSession GetSession(string sessionId);

        bool ContainsSession(string sessionId);
    }
}
