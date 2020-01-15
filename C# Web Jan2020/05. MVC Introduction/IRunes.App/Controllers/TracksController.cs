namespace IRunes.App.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using IRunes.Models;
    using IRunes.Services;
    using SIS.MvcFramework;
    using IRunes.App.Extensions;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;

    public class TracksController : Controller
    {
        private readonly ITrackService trackService;
        private readonly IAlbumService albumService;

        public TracksController()
        {
            this.trackService = new TrackService();
            this.albumService = new AlbumService();
        }

        [Authorize]
        public ActionResult Create()
        {
            string albumId = this.Request.QueryData["albumId"].ToString();

            this.ViewData["AlbumId"] = albumId;

            return this.View();
        }

        [Authorize]
        [HttpPost(ActionName = "Create")]
        public ActionResult CreateConfirm()
        {
            string albumId = this.Request.QueryData["albumId"].ToString();

            string name = ((ISet<string>)this.Request.FormData["name"]).FirstOrDefault();
            string link = ((ISet<string>)this.Request.FormData["link"]).FirstOrDefault();
            string price = ((ISet<string>)this.Request.FormData["price"]).FirstOrDefault();

            Track trackFromDb = new Track
            {
                Name = name,
                Link = link,
                Price = decimal.Parse(price)
            };

            if (this.albumService.AddTrackToAlbum(albumId, trackFromDb))
            {
                return Redirect("/Albums/All");
            }

            return this.Redirect($"/Albums/Details?id={albumId}");
        }

        [Authorize]
        public ActionResult Details()
        {
            string albumId = this.Request.QueryData["albumId"].ToString();
            string trackId = this.Request.QueryData["trackId"].ToString();


            Track trackFromDb = this.trackService.GetTrackById(trackId);

            if (trackFromDb == null)
            {
                return this.Redirect($"/Albums/Details?id={albumId}");
            }

            this.ViewData["AlbumId"] = albumId;
            this.ViewData["Track"] = trackFromDb.ToHtmlDetails(albumId);

            return this.View();
        }
    }
}
