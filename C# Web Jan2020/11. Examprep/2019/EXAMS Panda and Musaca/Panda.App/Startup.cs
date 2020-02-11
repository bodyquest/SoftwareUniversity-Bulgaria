namespace Panda.App
{
    using Panda.Data;
    using Panda.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Routing;
    using SIS.MvcFramework.DependencyContainer;
    using Microsoft.EntityFrameworkCore;

    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var context = new PandaAppDBContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUserService, UserService>();
            serviceProvider.Add<IPackageService, PackageService>();
            serviceProvider.Add<IReceiptServices, ReceiptServices>();
        }
    }
}
