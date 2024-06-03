using AutoMapper;
using Chinook.Core;
using Chinook.Core.Models;
using Chinook.Infrastructure;
using Chinook.Services.UserPlaylists.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services.UserPlaylists
{
    public class UserPlaylistService : IUserPlaylistService
    {
        private readonly ChinookContext _context;
        private readonly IMapper _mapper;

        public UserPlaylistService(ChinookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> ToggleUserPlaylistAsync(ToggleUserPlaylistRequest input)
        {
            long playlistId = 0;

            // Create Playlist Track
            var userPlaylist = await _context.UserPlaylists
                .Include(p => p.Playlist)
                .FirstOrDefaultAsync(up => up.UserId == input.UserId && up.Playlist.Name.Equals(ChinookConsts.MyFavorites));

            if (userPlaylist is null)
            {
                var favoritePlaylist = await CreateFavoritePlaylistAsync();

                userPlaylist = new UserPlaylist
                {
                    UserId = input.UserId,
                    PlaylistId = favoritePlaylist.PlaylistId,
                };
                _context.UserPlaylists.Add(userPlaylist);
                await _context.SaveChangesAsync();

                playlistId = favoritePlaylist.PlaylistId;
            }
            else
            {
                playlistId = userPlaylist.PlaylistId;
            }

            if (input.IsFavorite)
            {
                await AddTrackToPlaylistAsync(playlistId, input.TrackId);
            }
            else
            {
                await RemoveTrackFromPlaylistAsync(playlistId, input.TrackId);
            }

            return true;
        }

        private async Task<Playlist> CreateFavoritePlaylistAsync()
        {
            var favorite = new Playlist
            {
                Name = ChinookConsts.MyFavorites,
            };

            await _context.Playlists.AddAsync(favorite);

            await _context.SaveChangesAsync();
            return favorite;
        }

        public async Task<bool> AddTrackToPlaylistAsync(long playlistId, long trackId)
        {
            var playlist = await _context.Playlists.Include(p => p.Tracks).FirstOrDefaultAsync(p => p.PlaylistId == playlistId);
            var track = await _context.Tracks.FirstOrDefaultAsync(t => t.TrackId == trackId);

            if (playlist != null && track != null)
            {
                playlist.Tracks.Add(track);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveTrackFromPlaylistAsync(long playlistId, long trackId)
        {
            var playlist = await _context.Playlists.Include(p => p.Tracks).FirstOrDefaultAsync(p => p.PlaylistId == playlistId);
            var track = await _context.Tracks.FirstOrDefaultAsync(t => t.TrackId == trackId);

            if (playlist != null && track != null)
            {
                playlist.Tracks.Remove(track);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
