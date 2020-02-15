using SIS.MvcFramework;
using System;
using System.Threading.Tasks;

namespace MishMash.App
{
    public class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
