namespace Andreys.Services
{
    using Andreys.Data;
    using Andreys.Models;
    using SIS.MvcFramework;
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UserService : IUserService
    {
        private readonly AndreysDbContext context;

        public UserService(AndreysDbContext context)
        {
            this.context = context;
        }

        public bool EmailExists(string email)
        {
            var emailFromDb = this.context.Users
                .Where(x => x.Email == email)
                .Select(x => x.Email)
                .FirstOrDefault();

            if (emailFromDb == null)
            {
                return false;
            }

            return true;
        }

        public string GetUserIdOrNull(string username, string password)
        {
            var passwordHash = this.HashPassword(password);
            var userFromDb = this.context.Users
                .FirstOrDefault(user 
                    => (user.Username == username || user.Email == username) 
                    && user.Password == passwordHash);

            if (userFromDb == null)
            {
                return null;
            }

            return userFromDb.Id;
        }

        public void Register(string username, string email, string password)
        {
            var user = new User
            {
                Role = IdentityRole.User,
                Username = username,
                Email = email,
                Password = this.HashPassword(password)
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public bool UsernameExists(string username)
        {
            var usernameFromDb = this.context.Users
                .Where(x => x.Username == username)
                .Select(x => x.Username)
                .FirstOrDefault();

            if (usernameFromDb == null)
            {
                return false;
            }

            return true;
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
