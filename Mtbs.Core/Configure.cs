using Microsoft.Extensions.DependencyInjection;

namespace Mtbs.Core
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IAuthService, AuthService>();
        }
    }
}
