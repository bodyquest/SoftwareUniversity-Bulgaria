namespace ChushkaWebPREP.Controllers
{
    using ChushkaWebPREP.Data;
    using SIS.MvcFramework;

    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Context = new ApplicationDbContext();
        }

        public ApplicationDbContext Context { get; }
    }
}
