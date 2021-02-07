using System;
using System.Collections.Generic;
using WebApi.Core.Models;
using WebApi.Core.Shared;

namespace WebApi.Core.Blog
{
    public interface IReadPosts
    {
        OperationResult<IReadOnlyCollection<Post>> GetPosts();

        OperationResult<Post> GetPostsById(string id);
    }
}
