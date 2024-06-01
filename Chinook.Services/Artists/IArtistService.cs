using Chinook.Services.Artists.Dtos;

namespace Chinook.Services.Artists
{
    public interface IArtistService
    {
        Task<List<ArtistWithAlbumCountDto>> GetAll(GetArtistsRequestDto input);

        Task<ArtistDto> Get(long id);
    }
}
