using System.Collections.Generic;

namespace WebApi.Core.Models
{
    public record Blog
    {
        public IReadOnlyCollection<Post> Posts { get; init; } = new List<Post>();
    }
}
