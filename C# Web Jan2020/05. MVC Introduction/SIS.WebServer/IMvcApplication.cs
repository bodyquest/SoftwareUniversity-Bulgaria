namespace SIS.MvcFramework
{
    using SIS.MvcFramework.Routing;

    public interface IMvcApplication
    {
        void Configure(ServerRoutingTable serverRoutingTable);

        void ConfigureServices(); // for dependency injection
    }
}
