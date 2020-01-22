namespace IRunes.App.Controllers
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using SIS.MvcFramework;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework.Result;

    public class InfoController : Controller
    {
        public IHttpResponse About(IHttpRequest request)
        {
            return this.View();
        }

        public ActionResult Json(IHttpRequest request)
        {
            return Json(new { });
        }

        public ActionResult File(IHttpRequest request)
        {
            string folderPrefix = "/../";
            string assemblyLocation = this.GetType().Assembly.Location;
            string resourceFolder = "Resources/";
            string requestedResource = request.QueryData["file"].ToString();

            string fullResourcePath = assemblyLocation + folderPrefix + resourceFolder + requestedResource;

            if (System.IO.File.Exists(fullResourcePath))
            {
                //TODO: do this!!!
                string mimeType = null;
                string fileName = null;
                byte[] content = System.IO.File.ReadAllBytes(fullResourcePath);
                return File(content);
            }

            return NotFound();
        }
    }
}
