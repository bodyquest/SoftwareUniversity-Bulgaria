namespace MishMashWebPREP.Controllers
{
    using MishMashWebPREP.Data;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Context = new ApplicationDbContext();
        }

        public ApplicationDbContext Context { get; }
    }
}
