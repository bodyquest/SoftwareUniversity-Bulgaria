namespace SharedTrip
{
    using System.Collections.Generic;
    using SharedTrip.Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            var context = new ApplicationDbContext();

            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUserService, UserService>();
            serviceCollection.Add<ITripService, TripService>();
        }
    }
}
