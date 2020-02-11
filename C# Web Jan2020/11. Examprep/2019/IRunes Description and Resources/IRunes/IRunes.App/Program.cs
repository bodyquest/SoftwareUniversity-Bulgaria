namespace IRunes.App
{
    using System.Threading.Tasks;

    using SIS.MvcFramework;

    public static class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
