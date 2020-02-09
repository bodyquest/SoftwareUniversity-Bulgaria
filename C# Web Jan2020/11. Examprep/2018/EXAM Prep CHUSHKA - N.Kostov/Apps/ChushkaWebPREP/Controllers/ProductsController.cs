namespace ChushkaWebPREP.Controllers
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;

    public class ProductsController : BaseController
    {
        [Authorize]
        public IHttpResponse All()
        {
            return this.View();
        }

        [Authorize]
        public IHttpResponse Create()
        {

            return this.View();
        }

        //[Authorize]
        //[HttpPost]
        //public IHttpResponse Create()
        //{

        //    return this.View();
        //}

        [Authorize]
        public IHttpResponse Details()
        {

            return this.View();
        }
    }
}
