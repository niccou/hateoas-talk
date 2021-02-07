using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Core.Models;
using WebApi.Core.Services;
using WebApi.Core.Shared;

namespace WebApi.Core.Blog
{
    internal class ReadPosts : IReadPosts
    {
        private readonly IGetBlog _blog;

        public ReadPosts(IGetBlog blog)
        {
            _blog = blog;
        }

        public OperationResult<IReadOnlyCollection<Post>> GetPosts()
            => GetPosts(_ => true);

        public OperationResult<Post> GetPostsById(string id)
        {
            var posts = GetPosts(_ => _.Id == id);

            if (!posts.Success)
            {
                return OperationResult<Post>.Failed();
            }

            return OperationResult<Post>.Succeed(posts.Result!.Single());
        }

        private OperationResult<IReadOnlyCollection<Post>> GetPosts(Func<Post, bool> predicate)
        {
            var posts = _blog.Get();

            if (!posts.Success)
            {
                return (OperationResult<IReadOnlyCollection<Post>>)OperationResult.Failed();
            }

            return OperationResult<IReadOnlyCollection<Post>>
                .Succeed(new List<Post>(posts.Result?.Posts.Where(predicate) ?? Enumerable.Empty<Post>()));
        }
    }
}
