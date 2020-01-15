namespace IRunes.Services
{
    using IRunes.Models;

    public interface ITrackService
    {
        Track GetTrackById(string trackId);
    }
}
