using Chinook.Services.UserPlaylists.Dtos;

namespace Chinook.Services.UserPlaylists
{
    public interface IUserPlaylistService
    {
        Task<bool> ToggleUserPlaylistAsync(ToggleUserPlaylistRequest input);

        Task<bool> RemoveTrackFromPlaylistAsync(long playlistId, long trackId);
    }
}
