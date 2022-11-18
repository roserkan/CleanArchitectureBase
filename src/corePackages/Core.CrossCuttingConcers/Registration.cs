using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns;

public static class CrossCuttingConcernsServiceRegistration
{
    public static IServiceCollection AddCrossCuttingConcernsServices(this IServiceCollection services)
    {
        services.AddStackExchangeRedisCache(options => options.Configuration = "localhost:6379");
        return services;
    }
}
