using System.Collections.Generic;
using WebApi.Core.Models;

namespace WebApi.Core.Blog
{
    public interface IReadPosts
    {
        IReadOnlyCollection<Post> Posts { get; }

        IReadOnlyCollection<Post> PostsByAuthor(Author author);
    }
}
