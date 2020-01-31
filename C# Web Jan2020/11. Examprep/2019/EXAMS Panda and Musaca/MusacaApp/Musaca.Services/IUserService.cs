namespace Musaca.Services
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Musaca.Models;

    public interface IUserService
    {
        string CreateUser(string username, string email, string password);

        User GetUserOrNull(string username, string password);

        IEnumerable<string> GetUsernames();
    }
}
