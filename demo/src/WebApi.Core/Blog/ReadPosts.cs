using System.Collections.Generic;
using System.Linq;
using WebApi.Core.Models;
using static WebApi.Core.Models.Post.PostState;
namespace WebApi.Core.Blog
{
    internal class ReadPosts : IReadPosts
    {
        private readonly IGetBlog _blog;

        public ReadPosts(IGetBlog blog)
        {
            _blog = blog;
        }

        public IReadOnlyCollection<Post> Posts => _blog.Get().Posts.Where(_ => _.State == Published).ToList();

        public IReadOnlyCollection<Post> PostsByAuthor(Author author) =>
            _blog.Get().Posts.Where(_ => _.State == Published || (_.State == Draft && _.Author.Name == author.Name)).ToList();
    }
}
