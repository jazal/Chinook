using AutoMapper;
using Chinook.Core.Models;
using Chinook.Services.Artists.Dtos;

namespace Chinook.Services.Artists.MappingProfile
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<Artist, ArtistWithAlbumCountDto>()
                .ForMember(dest => dest.AlbumCount, opt => opt.MapFrom(src => src.Albums.Count));
        }
    }
}
