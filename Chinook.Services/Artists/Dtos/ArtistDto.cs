using AutoMapper;
using Chinook.Core.Models;

namespace Chinook.Services.Artists.Dtos
{
    [AutoMap(typeof(Artist), ReverseMap = true)]
    public class ArtistDto
    {
        public long ArtistId { get; set; }
        public string? Name { get; set; }
    }
}
