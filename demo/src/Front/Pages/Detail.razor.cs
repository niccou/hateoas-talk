using Front.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Front.Pages
{
    public partial class Detail
    {
        [Inject]
        public HttpClient Client { get; set; } = new HttpClient();

        [Inject]
        public PostDetailDto DetailLink { get; set; } = new PostDetailDto();

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        public PostDetail Post { get; set; } = new PostDetail();

        protected async override Task OnInitializedAsync()
        {
            if (string.IsNullOrWhiteSpace(DetailLink.Detail.Rel))
            {
                NavigationManager?.NavigateTo("/");
                return;
            }

            await RequestApiAsync(DetailLink.Detail.Href, DetailLink.Detail.Type).ConfigureAwait(false);
        }

        private bool CanPublish =>
            PublishLink is not null;

        private bool CanUnpublish =>
            UnpublishLink is not null;

        private Link? PublishLink => Post.Links.SingleOrDefault(_ => _.Rel == "publish");
        private Link? UnpublishLink => Post.Links.SingleOrDefault(_ => _.Rel == "unpublish");

        private async Task PublishAsync()
        {
            if (CanPublish)
            {
                await RequestApiAsync(PublishLink!.Href, PublishLink.Type).ConfigureAwait(false);
            }
        }

        private async Task RequestApiAsync(string href, string method)
        {
            var request = RequestHelper.CreateRequest(href, method);

            var response = await Client.SendAsync(request).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            Post = content.Deserialize<Response<PostDetail>>()?.Result ?? new PostDetail();
        }

        private async Task UnpublishAsync()
        {
            if (CanUnpublish)
            {
                await RequestApiAsync(UnpublishLink!.Href, UnpublishLink.Type).ConfigureAwait(false);
            }
        }
    }
}