using IRunes.App.Controllers;
using IRunes.Data;
using SIS.HTTP.Enums;
using SIS.MvcFramework;
using SIS.MvcFramework.Result;
using SIS.MvcFramework.Routing;

namespace IRunes.App
{
    public class Startup : IMvcApplication
    {
        /*
         * ALL SETTINGS OF THE APPLICATION
         Routing Tables
         ...

         */
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var context = new RunesDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void ConfigureServices()
        {
        }
    }
}