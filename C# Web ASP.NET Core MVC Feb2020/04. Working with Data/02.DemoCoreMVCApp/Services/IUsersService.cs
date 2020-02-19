using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02.DemoCoreMVCApp.Services
{
    public interface IUsersService
    {
        int GetCount();

        IEnumerable<string> GetUsernames();

        string LatestUsername();
    }
}
