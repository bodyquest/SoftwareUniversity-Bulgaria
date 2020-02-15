namespace MishMash.App
{
    using MishMash.Data;
    using MishMash.Services;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            var context = new ApplicationDbContext();
            //context.Database.Ensure.Deleted();
            context.Database.EnsureCreated();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUserService, UserService>();
            //serviceCollection.Add<>();
            //serviceCollection.Add<>();
            //serviceCollection.Add<>();
        }
    }
}
