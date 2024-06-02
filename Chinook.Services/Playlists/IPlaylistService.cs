using Chinook.Services.Playlists.Dtos;

namespace Chinook.Services.Playlists
{
    public interface IPlaylistService
    {
        Task<List<PlaylistDto>> GetAll(GetPlaylistsRequestDto input);

        Task AddTrackToPlaylistAsync(AddTrackToPlaylistRequestDto input);
    }
}
