namespace IRunes.Services
{
    using IRunes.Models;
    using System;

    public interface IUserService
    {
        User CreateUser(User user);

        User GetByUsernameAndPassword(string username, string password);
    }
}
