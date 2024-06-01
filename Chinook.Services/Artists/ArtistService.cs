using AutoMapper;
using Chinook.Core.Extensions;
using Chinook.Infrastructure;
using Chinook.Services.Artists.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace Chinook.Services.Artists
{
    public class ArtistService : IArtistService
    {
        private readonly ChinookContext _context;
        private readonly IMapper _mapper;

        public ArtistService(ChinookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ArtistDto> Get(long id)
        {
            var artist = await _context.Artists
                    .FirstOrDefaultAsync(a => a.ArtistId == id);
            return _mapper.Map<ArtistDto>(artist);
        }

        public async Task<List<ArtistWithAlbumCountDto>> GetAll(GetArtistsRequestDto input)
        {
            try
            {
                if (!string.IsNullOrEmpty(input.Keyword)) input.Keyword = input.Keyword.ToUpper();

                var artists = await _context.Artists
                    .Include(a => a.Albums)
                    .WhereIf(!string.IsNullOrEmpty(input.Keyword),
                        a => a.Name.ToUpper().Contains(input.Keyword)
                    )
                    .ToListAsync();
                return _mapper.Map<List<ArtistWithAlbumCountDto>>(artists);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
