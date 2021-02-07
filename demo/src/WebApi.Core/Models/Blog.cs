using System.Collections.Generic;

namespace WebApi.Core.Models
{
    public record Blog
    {
        public Blog() : this(new List<Post>()) { }

        public Blog(IReadOnlyCollection<Post> posts)
        {
            Posts = posts ?? new List<Post>();
        }

        public IReadOnlyCollection<Post> Posts { get; init; } = new List<Post>();
    }
}
