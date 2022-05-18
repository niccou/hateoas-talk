using Front.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Front.Components.Blog
{
    public partial class BlogTableRow
    {
        [Inject]
        public PostDetailDto Detail { get; set; } = new();

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Parameter]
        public Post Post { get; set; } = new();

        [Parameter]
        public Action<Link>? Publish { get; set; }

        public Task PublishPost() => Task.Run(() => Publish?.Invoke(Post.Links.PublishPost()!));

        [Parameter]
        public Action<Link>? Unpublish { get; set; }

        public Task UnpublishPost() => Task.Run(() => Publish?.Invoke(Post.Links.UnpublishPost()!));

        private void NavigateToDetail()
        {
            Detail.Detail = Post.DetailLink;

            NavigationManager?.NavigateTo("/Detail");
        }
    }
}