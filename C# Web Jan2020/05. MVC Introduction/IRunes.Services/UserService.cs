namespace IRunes.Services
{
    using System.Linq;
    using System.Collections.Generic;

    using IRunes.Data;
    using IRunes.Models;

    public class UserService : IUserService
    {
        private readonly RunesDbContext context;

        public UserService()
        {
            this.context = new RunesDbContext();
        }

        public User CreateUser(User user)
        {
            user = context.Users.Add(user).Entity;
            this.context.SaveChanges();

            return user;
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return this.context.Users.SingleOrDefault(user => (user.Username == username || user.Email == username)&& user.Password == password);
        }
    }
}
