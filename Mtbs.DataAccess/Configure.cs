using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mtbs.DataAccess
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MtbsContext>(
                opt => opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("Mtbs.Api")));

            services
                .AddScoped<IMoviesRepository, MoviesRepository>()
                .AddScoped<ICitiesRepository, CitiesRepository>();
        }
    }
}
