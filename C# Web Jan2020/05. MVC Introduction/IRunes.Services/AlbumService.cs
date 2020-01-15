namespace IRunes.Services
{
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using IRunes.Data;
    using IRunes.Models;

    public class AlbumService : IAlbumService
    {
        private readonly RunesDbContext context;

        public AlbumService()
        {
            this.context = new RunesDbContext();
        }

        public Album CreateAlbum(Album album)
        {
            album = context.Albums.Add(album).Entity;
            this.context.SaveChanges();

            return album;
        }

        public bool AddTrackToAlbum(string albumId, Track trackFromDb)
        {

            Album albumFromDb = this.GetAlbumById(albumId);
            if (albumFromDb == null)
            {
                return false;
            }

            albumFromDb.Tracks.Add(trackFromDb);
            albumFromDb.Price = (albumFromDb.Tracks.Select(track => track.Price).Sum() * 87) / 100;

            this.context.Update(albumFromDb);
            this.context.SaveChanges();

            return true;
        }

        public Album GetAlbumById(string id)
        {
            return context.Albums
                .Include(a => a.Tracks)
                .SingleOrDefault(a => a.Id == id);
        }

        public ICollection<Album> GetAllAlbums()
        {
            return context.Albums.ToList();
        }
    }
}
