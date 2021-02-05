using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Repository.Configuration
{
    public static class ConfigureCore
    {
        public static IServiceCollection AddWebApiRepositoryConfiguration(this IServiceCollection services)
            => services;
    }
}
