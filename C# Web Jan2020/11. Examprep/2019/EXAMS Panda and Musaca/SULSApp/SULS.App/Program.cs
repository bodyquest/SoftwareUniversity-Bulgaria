namespace SULS.App
{
    using System.Threading;
    using System.Globalization;

    using SIS.MvcFramework;

    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            WebHost.Start(new Startup());
        }
    }
}
