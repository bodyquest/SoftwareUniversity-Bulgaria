namespace ChushkaWebPREP
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Services;

    public class Startup : IMvcApplication
    {
        public MvcFrameworkSettings Configure()
        {
            return new MvcFrameworkSettings();
        }

        public void ConfigureServices(IServiceCollection collection)
        {
        }
    }
}
