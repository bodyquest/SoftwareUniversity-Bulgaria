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

            #region Seed Countries
            
            #endregion

            #region Seed Cities

            #endregion

            #region Seed Towns

            #endregion

            #region Seed Users

            #endregion

            #region Seed Images

            #endregion

            #region Seed Properties

            #endregion


        }
    }
}
