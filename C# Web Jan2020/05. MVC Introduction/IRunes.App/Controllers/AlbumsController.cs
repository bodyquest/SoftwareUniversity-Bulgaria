namespace IRunes.App.Controllers
{
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using IRunes.Models;
    using IRunes.Services;
    using SIS.MvcFramework;
    using IRunes.App.ViewModels;
    using IRunes.App.Extensions;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Mapping;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;

    public class AlbumsController : Controller
    {
        private readonly IAlbumService albumService;

        public AlbumsController()
        {
            this.albumService = new AlbumService();
        }

        [Authorize]
        public ActionResult All()
        {

            ICollection<Album> allAlbums = this.albumService.GetAllAlbums();

            if (allAlbums.Count == 0)
            {
                this.ViewData["Albums"] = "There are currently no albums.";
            }
            else
            {
                this.ViewData["Albums"] =
                    string.Join(string.Empty,
                    allAlbums.Select(album => album.ToHtmlAll())
                    .ToList());
            }

            return this.View();
        }

        [Authorize]
        public ActionResult Create()
        {
            return this.View();
        }

        [Authorize()]
        [HttpPost(ActionName = "Create")]
        public ActionResult CreateConfirm()
        {
            string name = ((ISet<string>)this.Request.FormData["name"]).FirstOrDefault();
            string cover = ((ISet<string>)this.Request.FormData["cover"]).FirstOrDefault();

            Album album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0m
            };

            this.albumService.CreateAlbum(album);


            return this.Redirect("/Albums/All");
        }

        [Authorize]
        public ActionResult Details()
        {
            string albumId = this.Request.QueryData["id"].ToString();

            Album albumFromDb = this.albumService.GetAlbumById(albumId);

            AlbumViewModel albumViewModel = ModelMapper.ProjectTo<AlbumViewModel>(albumFromDb);

            if (albumFromDb == null)
            {
                return Redirect("/Albums/All");
            }

            this.ViewData["Album"] = albumFromDb.ToHtmlDetails();
            return this.View();

        }
    }
}
