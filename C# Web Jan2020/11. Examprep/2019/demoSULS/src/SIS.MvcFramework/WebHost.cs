namespace SIS.MvcFramework
{
    using SIS.HTTP;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public static class WebHost
    {
        public static async Task StartAsync(IMvcApplication application)
        {
            var routeTable = new List<Route>();
            application.ConfigureServices();
            application.Configure(routeTable);
            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }
    }
}
