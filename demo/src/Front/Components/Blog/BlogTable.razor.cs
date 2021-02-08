using Front.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Front.Components.Blog
{
    public partial class BlogTable
    {
        [Parameter]
        public IReadOnlyCollection<Post> Posts { get; set; } = new List<Post>();

        private bool HasDetailLink(Post post) => DetailLink(post) is not null;
        private Link? DetailLink(Post post) => post.Links.FirstOrDefault(_ => _.Rel == "detail");

    }
}
