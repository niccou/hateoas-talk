using Front.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Front.Components.Blog
{
    public partial class BlogTable
    {
        [Parameter]
        public IReadOnlyCollection<Post> Posts { get; set; } = new List<Post>();
    }
}