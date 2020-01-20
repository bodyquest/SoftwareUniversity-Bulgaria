namespace IRunes.App
{
    using IRunes.Data;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Routing;

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