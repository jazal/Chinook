using AutoMapper;
using Chinook.Core;
using Chinook.Infrastructure;
using Chinook.Services.Tracks.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services.Tracks
{
    public class TrackService : ITrackService
    {
        private readonly ChinookContext _context;
        private readonly IMapper _mapper;

        public TrackService(ChinookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PlaylistTrackDto>> GetAlbumTracks(long artistId, string userId)
        {
            return await _context.Tracks.Where(a => a.Album.ArtistId == artistId)
               .Include(a => a.Album)
               .Select(t => new PlaylistTrackDto()
               {
                   AlbumTitle = (t.Album == null ? "-" : t.Album.Title),
                   TrackId = t.TrackId,
                   TrackName = t.Name,
                   IsFavorite = 
                        t.Playlists
                        .Where(p => p.UserPlaylists.Any(up => up.UserId == userId && up.Playlist.Name == ChinookConsts.MyFavorites))
                        .Any()
               })
               .ToListAsync();
        }
    }
}
