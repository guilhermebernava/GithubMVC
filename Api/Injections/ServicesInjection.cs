using Api.Services;
using Api.Services.Interfaces;

namespace Api.Injections;

public static class ServicesInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IGithubServices, GithubServices>();
        services.AddSingleton<IFavoriteServices, FavoriteServices>();
        services.AddScoped<IHttpServices, HttpServices>();
    }
}
