namespace Chinook.Services.Playlists.Dtos
{
    public class AddTrackToPlaylistRequestDto
    {
        public string? NewPlaylist { get; set; }

        public long? PlaylistId { get; set; }
        
        public long TrackId { get; set; }

    }
}
