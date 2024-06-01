using AutoMapper;
using Chinook.Core;
using Chinook.Core.Models;
using Chinook.Infrastructure;
using Chinook.Services.Tracks.Dtos;
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
            var favoritePlaylist = await GetOrCreateFavoritePlaylistAsync();

            // Create Playlist Track
            
            var userPlaylist = await _context.UserPlaylists
                .Include(p => p.Playlist)
                .FirstOrDefaultAsync(up => up.UserId == input.UserId && up.Playlist.Name.Equals(ChinookConsts.MyFavorites));

            if (userPlaylist is not null)
            {
                _context.UserPlaylists.Remove(userPlaylist);
            }
            else
            {
                userPlaylist = new UserPlaylist
                {
                    UserId = input.UserId,
                    PlaylistId = input.TrackId,
                };
                _context.UserPlaylists.Add(userPlaylist);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<Playlist> GetOrCreateFavoritePlaylistAsync()
        {
            var favorite = await _context.Playlists
                .FirstOrDefaultAsync(p => p.Name.Equals(ChinookConsts.MyFavorites));

            if (favorite is not null) return favorite;

            favorite = new Playlist
            {
                Name = ChinookConsts.MyFavorites,
            };

            await _context.Playlists.AddAsync(favorite);
            
            await _context.SaveChangesAsync();
            return favorite;
        }
    }
}
