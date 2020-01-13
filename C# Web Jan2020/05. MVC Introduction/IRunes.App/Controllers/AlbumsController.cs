namespace IRunes.App.Controllers
{
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using IRunes.Data;
    using IRunes.Models;
    using SIS.MvcFramework;
    using IRunes.App.Extensions;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;

    public class AlbumsController : Controller
    {
        [Authorize()]
        public ActionResult All()
        {
            using (var context = new RunesDbContext())
            {
                ICollection<Album> allAlbums = context.Albums.ToList();

                if (allAlbums.Count == 0)
                {
                    this.ViewData["Albums"] = "There are currently no albums.";
                }
                else
                {
                    this.ViewData["Albums"] = 
                        string.Join(string.Empty,
                        allAlbums.Select(album => album.ToHtmlAll()).ToList());
                }

                return this.View();
            }
        }

        [Authorize()]
        public ActionResult Create()
        {
            return this.View();
        }

        [Authorize()]
        [HttpPost(ActionName = "Create")]
        public ActionResult CreateConfirm()
        {
            using (var context = new RunesDbContext())
            {
                string name = ((ISet<string>)this.Request.FormData["name"]).FirstOrDefault();
                string cover = ((ISet<string>)this.Request.FormData["cover"]).FirstOrDefault();
                
                Album album = new Album
                {
                    Name = name,
                    Cover = cover,
                    Price = 0m
                };

                context.Albums.Add(album);
                context.SaveChanges();
            }

            return this.Redirect("/Albums/All");
        }

        [Authorize()]
        public ActionResult Details()
        {
            string albumId = this.Request.QueryData["id"].ToString();

            using (var context = new RunesDbContext())
            {
                Album albumFromDb = context.Albums
                    .Include(Album => Album.Tracks)
                    .SingleOrDefault(album => album.Id == albumId);

                if (albumFromDb == null)
                {
                    return Redirect("/Albums/All");
                }

                this.ViewData["Album"] = albumFromDb.ToHtmlDetails();
                return this.View();
            }
        }
    }
}
