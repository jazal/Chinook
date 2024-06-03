using Chinook.Services.Playlists.Dtos;

namespace Chinook.Services.Playlists
{
    public interface IPlaylistService
    {
        Task<List<PlaylistDto>> GetAll(GetPlaylistsRequestDto input);

        Task<bool> IsPlaylistNameExist(string playlistName);

        Task AddTrackToPlaylistAsync(AddTrackToPlaylistRequestDto input);

        Task<List<PlaylistDto>> GetPlaylistsByTrack(long trackId);

        Task<PlaylistVM> GetPlaylistTracks(long playlistId, string currentUserId);
    }
}
