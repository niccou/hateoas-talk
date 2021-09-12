using Front.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;

namespace Front.Components.Blog
{
    public partial class BlogTableRow
    {
        [Inject] public ILogger<BlogTableRow>? Logger { get; set; }

        [Inject]
        public PostDetailDto Detail { get; set; } = new PostDetailDto();

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Parameter]
        public Post Post { get; set; } = new Post();

        [Parameter]
        public Action<Link>? Publish { get; set; }

        private void PublishPost()
        {
            Logger.LogWarning(nameof(PublishPost));
            Publish?.Invoke(Post.Links.PublishPost()!);
            StateHasChanged();
        }

        [Parameter]
        public Action<Link>? Unpublish { get; set; }

        private void UnpublishPost()
        {
            Logger.LogWarning(nameof(UnpublishPost));
            Publish?.Invoke(Post.Links.UnpublishPost()!);
            StateHasChanged();
        }

        private void NavigateToDetail()
        {
            Logger.LogWarning(nameof(NavigateToDetail));
            Detail.Detail = Post.DetailLink;

            NavigationManager?.NavigateTo("/Detail");
        }
    }
}