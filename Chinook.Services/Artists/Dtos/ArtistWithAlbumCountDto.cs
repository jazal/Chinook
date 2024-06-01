namespace Chinook.Services.Artists.Dtos
{
    public class ArtistWithAlbumCountDto
    {
        public long ArtistId { get; set; }
        public string? Name { get; set; }
        public int AlbumCount { get; set; }
    }
}
