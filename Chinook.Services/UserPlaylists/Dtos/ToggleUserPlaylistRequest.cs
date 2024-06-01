namespace Chinook.Services.UserPlaylists.Dtos
{
    public class ToggleUserPlaylistRequest
    {
        public string UserId { get; set; }
        public long TrackId { get; set; }
        public bool IsFavorite { get; set; }
    }
}
