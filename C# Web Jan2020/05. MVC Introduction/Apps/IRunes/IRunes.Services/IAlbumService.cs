namespace IRunes.Services
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using IRunes.Models;

    public interface IAlbumService
    {
        Album CreateAlbum(Album album);

        bool AddTrackToAlbum(string albumId, Track track);

        ICollection<Album> GetAllAlbums();

        Album GetAlbumById(string id);
        
    }
}
 