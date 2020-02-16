﻿namespace SharedTrip.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IUserService
    {
        string GetUserId(string username, string password);

        void Register(string username, string email, string password);

        bool UsernameExists(string username);

        bool EmailExists(string email);

        string GetUsername(string id);
    }
}
