namespace Chinook.Services.Playlists.Dtos
{
    public class PlaylistVM
    {
        public string Name { get; set; }
        public List<PlaylistTrackVM> Tracks { get; set; }
    }

    public class PlaylistTrackVM
    {
        public long TrackId { get; set; }
        public string TrackName { get; set; }
        public string AlbumTitle { get; set; }
        public string ArtistName { get; set; }
        public bool IsFavorite { get; set; }
    }
}
