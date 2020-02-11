namespace SULS.App
{
    using SULS.Data;
    using SULS.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Routing;
    using SIS.MvcFramework.DependencyContainer;

    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var context = new SulsAppDbContext())
            {
                //comntext.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUserService, UserService>();
            serviceProvider.Add<IProblemService, ProblemService>();
            serviceProvider.Add<ISubmissionService, SubmissionService>();
        }
    }
}
