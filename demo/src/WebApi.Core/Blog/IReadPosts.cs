using System.Collections.Generic;
using WebApi.Core.Models;

namespace WebApi.Core.Blog
{
    public interface IReadPosts
    {
        IReadOnlyCollection<Post> Posts { get; }
    }
}
