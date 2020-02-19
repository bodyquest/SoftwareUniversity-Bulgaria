using _02.DemoCoreMVCApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02.DemoCoreMVCApp.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext context;

        public UsersService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int GetCount()
        {
            return this.context.Users.Count();
        }

        public IEnumerable<string> GetUsernames()
        {
            return this.context.Users.Select(x => x.UserName).ToList();
        }

        public string LatestUsername()
        {
            return this.context.Users.OrderByDescending(x => x.Email).Select(x => x.UserName).FirstOrDefault();
        }
    }
}
