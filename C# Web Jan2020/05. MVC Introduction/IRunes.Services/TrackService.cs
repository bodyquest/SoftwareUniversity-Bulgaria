namespace IRunes.Services
{
    using IRunes.Data;
    using IRunes.Models;
    using System.Linq;

    public class TrackService : ITrackService
    {
        private readonly RunesDbContext context;

        public TrackService()
        {
            this.context = new RunesDbContext();
        }

        public Track GetTrackById(string trackId)
        {
            return context.Tracks
                .SingleOrDefault(t => t.Id == trackId);
        }
    }
}
