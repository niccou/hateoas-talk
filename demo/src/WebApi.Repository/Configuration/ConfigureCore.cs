using Microsoft.Extensions.DependencyInjection;
using WebApi.Core.Services;
using WebApi.Repository.Blog;

namespace WebApi.Repository.Configuration
{
    public static class ConfigureCore
    {
        private static BlogManager Manager { get; } = new BlogManager();

        public static IServiceCollection AddWebApiRepositoryConfiguration(this IServiceCollection services)
            => services
            .AddTransient<IGetBlog>(_ => Manager)
            .AddTransient<IPublishPost>(_ => Manager);
    }
}
