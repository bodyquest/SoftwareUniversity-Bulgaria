namespace Musaca.Web
{
    using Musaca.Data;
    using Musaca.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Routing;
    using SIS.MvcFramework.DependencyContainer;

    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var context = new MusacaDbContext())
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            //ordered by dependency
            serviceProvider.Add<IUserService, UserService>();
            serviceProvider.Add<IProductService, ProductService>();
            serviceProvider.Add<IOrderService, OrderService>();
        }
    }
}
