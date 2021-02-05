using Microsoft.Extensions.DependencyInjection;
using WebApi.Core.Blog;
using WebApi.Repository.Blog;

namespace WebApi.Repository.Configuration
{
    public static class ConfigureCore
    {
        public static IServiceCollection AddWebApiRepositoryConfiguration(this IServiceCollection services)
            => services
            .AddSingleton<IGetBlog, GetBlog>();
    }
}
