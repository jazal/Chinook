using AutoMapper;
using Chinook.Core.Models;

namespace Chinook.Services.Playlists.Dtos
{
    [AutoMap(typeof(Playlist), ReverseMap = true)]
    public class PlaylistDto
    {
        public long PlaylistId { get; set; }

        public string? Name { get; set; }
    }
}
