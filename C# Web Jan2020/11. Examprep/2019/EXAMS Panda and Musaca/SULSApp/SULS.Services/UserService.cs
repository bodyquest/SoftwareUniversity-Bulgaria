namespace SULS.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    using SULS.Data;
    using SULS.Models;

    public class UserService : IUserService
    {
        private readonly SulsAppDbContext context;

        public UserService(SulsAppDbContext context)
        {
            this.context = context;
        }

        public string CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.HashPassowrd(password)
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();

            return user.Id;
        }

        public IEnumerable<string> GetUsernames()
        {
            var users = this.context.Users.Select(x => x.Username).ToList();

            return users;
        }

        public User GetUserOrNull(string username, string password)
        {
            User user = this.context.Users.FirstOrDefault(x => (x.Username == username || x.Email == username) && x.Password == this.HashPassowrd(password));

            return user;
        }



        private string HashPassowrd(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hashedPassword = Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));

                return hashedPassword;
            }
        }
    }
}
