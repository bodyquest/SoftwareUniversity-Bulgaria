namespace SULS.Services
{
    using System.Collections.Generic;

    using SULS.Models;

    public interface IUserService
    {
        string CreateUser(string username, string email, string password);

        User GetUserOrNull(string username, string password);

        IEnumerable<string> GetUsernames();
    }
}
