using Chinook.Areas.Identity;
using Chinook.Core.Models;
using Chinook.Services.Artists;
using Chinook.Services.Playlists;
using Chinook.Services.Tracks;
using Chinook.Services.UserPlaylists;
using Microsoft.AspNetCore.Components.Authorization;

namespace Chinook.Extensions
{
    public static class ServiceConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ChinookUser>>();

            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped<IUserPlaylistService, UserPlaylistService>();
            services.AddScoped<IPlaylistService, PlaylistService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
