using Chinook.Services.Tracks.Dtos;

namespace Chinook.Services.Tracks
{
    public interface ITrackService
    {
        Task<List<PlaylistTrackDto>> GetAlbumTracks(long artistId, string userId);
    }
}
