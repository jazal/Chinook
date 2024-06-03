using Chinook.Core.Models;
using Chinook.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Extensions
{
    public static class DatabaseConfiguration
    {
        public static void Configure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextFactory<ChinookContext>(opt => opt.UseSqlite(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ChinookUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ChinookContext>();
        }
    }
}
