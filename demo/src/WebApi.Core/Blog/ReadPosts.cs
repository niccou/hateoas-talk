using System.Collections.Generic;
using System.Linq;
using WebApi.Core.Models;

namespace WebApi.Core.Blog
{
    internal class ReadPosts : IReadPosts
    {
        private readonly IGetBlog _blog;

        public ReadPosts(IGetBlog blog)
        {
            _blog = blog;
        }

        public IReadOnlyCollection<Post> Posts => _blog.Get().Posts.Where(_ => _.State == Post.PostState.Published).ToList();
    }
}
