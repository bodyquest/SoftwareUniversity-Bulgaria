namespace Andreys.Services
{
    public interface IUserService
    {
        void Register(string username, string email, string password);

        string GetUserIdOrNull(string username, string password);

        bool EmailExists(string email);

        bool UsernameExists(string username);
    }
}
