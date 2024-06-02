using AutoMapper;
using Chinook.Core;
using Chinook.Core.Extensions;
using Chinook.Core.Models;
using Chinook.Infrastructure;
using Chinook.Services.Playlists.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Chinook.Services.Playlists
{
    public class PlaylistService : IPlaylistService
    {
        private readonly ChinookContext _context;
        private readonly IMapper _mapper;

        public PlaylistService(ChinookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PlaylistDto>> GetAll(GetPlaylistsRequestDto input)
        {
            return await _context.Playlists
                .WhereIf(input.IsFavoriteIncluded == false,
                    a => !a.Name.Equals(ChinookConsts.MyFavorites)
                )
                .Select(a => _mapper.Map<PlaylistDto>(a))
                .ToListAsync();
        }

        public async Task<bool> IsPlaylistNameExist(string playlistName)
        {
            return _context.Playlists.Any(p => p.Name.ToUpper().Equals(playlistName.ToUpper()));
        }

        public async Task AddTrackToPlaylistAsync(AddTrackToPlaylistRequestDto input)
        {
            try
            {
                if (!input.NewPlaylist.IsNullOrEmpty()) input.PlaylistId = await CreatePlaylistAsync(input.NewPlaylist);

                var playlist = await _context.Playlists.Include(p => p.Tracks).FirstOrDefaultAsync(p => p.PlaylistId == input.PlaylistId);
                var track = await _context.Tracks.FirstOrDefaultAsync(t => t.TrackId == input.TrackId);

                if (playlist != null && track != null && !playlist.Tracks.Contains(track))
                {
                    playlist.Tracks.Add(track);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PlaylistDto>> GetPlaylistsByTrack(long trackId)
        {
            try
            {
                return await _context.Tracks
                    .Include(t => t.Playlists)
                    .Where(t => t.TrackId == trackId)
                    .Select(t => t.Playlists)
                    .SelectMany(ps => ps)
                    .Select(p => _mapper.Map<PlaylistDto>(p))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<long> CreatePlaylistAsync(string playlistName)
        {
            var playlist = new Playlist { Name = playlistName };
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();
            return playlist.PlaylistId;
        }
    }
}
