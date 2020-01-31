namespace Panda.Services
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    using Panda.Data;
    using Panda.Models;

    public class UserService : IUserService
    {
        private readonly PandaAppDBContext db;

        public UserService(PandaAppDBContext PandaAppDBContext)
        {
            this.db = PandaAppDBContext;
        }

        public string CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password)
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user.Id;
        }

        public IEnumerable<string> GetUsernames()
        {
            var users = this.db.Users.Select(x => x.Username).ToList();
            return users;
        }

        public User GetUserOrNull(string username, string password)
        {
            var passwordHash = this.HashPassword(password);
            var userFromDb = this.db.Users.FirstOrDefault(user => (user.Username == username || user.Email == username) && user.Password == passwordHash);

            return userFromDb;
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
