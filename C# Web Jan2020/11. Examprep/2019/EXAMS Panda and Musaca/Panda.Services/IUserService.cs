namespace Panda.Services
{
    using System.Collections.Generic;

    using Panda.Models;

    public interface IUserService
    {
        string CreateUser(string username, string email, string password);

        User GetUserOrNull(string username, string password);

        IEnumerable<string> GetUsernames();
    }
}