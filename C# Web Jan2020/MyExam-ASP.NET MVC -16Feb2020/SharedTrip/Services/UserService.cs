namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool EmailExists(string email)
        {
            throw new NotImplementedException();
        }

        public string GetUserId(string username, string password)
        {
            var hashPassword = this.HashPassword(password);

            var user = this.context.Users.FirstOrDefault(u => u.Username == username && u.Password == hashPassword);

            if (user == null)
            {
                return null;
            }

            return user.Id;
        }

        public string GetUsername(string id)
        {
            var userName = this.context.Users
                .Where(u => u.Id == id)
                .Select(u => u.Username)
                .FirstOrDefault();

            if (userName == null)
            {
                return null;
            }

            return userName;
        }

        public void Register(string username, string email, string password)
        {
            var user = new User
            {
                Role = IdentityRole.User,
                Username = username,
                Email = email,
                Password = this.HashPassword(password),
            };
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public bool UsernameExists(string username)
        {
            throw new NotImplementedException();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
