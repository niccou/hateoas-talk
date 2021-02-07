using Microsoft.Extensions.DependencyInjection;
using WebApi.Core.Blog;

namespace WebApi.Core.Configuration
{
    public static class ConfigureCore
    {
        public static IServiceCollection AddWebApiCoreConfiguration(this IServiceCollection services)
            => services
            .AddTransient<IReadPosts, ReadPosts>()
            .AddTransient<IPublishPost, PublishPost>();
    }
}
