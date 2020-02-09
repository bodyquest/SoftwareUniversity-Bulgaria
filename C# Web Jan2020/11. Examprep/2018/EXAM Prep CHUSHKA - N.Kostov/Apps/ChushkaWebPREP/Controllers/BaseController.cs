namespace ChushkaWebPREP.Controllers
{
    using ChushkaWebPREP.Data;
    using SIS.MvcFramework;

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Context = new ApplicationDbContext();
        }

        public ApplicationDbContext Context { get; }
    }
}
