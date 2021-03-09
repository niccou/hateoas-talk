using Front.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Front.Pages
{
    public partial class Index
    {
        [Inject]
        public HttpClient Client { get; set; } = new HttpClient();

        public List<Post> Posts { get; set; } = new List<Post>();

        protected async override Task OnInitializedAsync()
        {
            var response = await Client.GetStringAsync(new Uri("/api/blog", UriKind.Relative)).ConfigureAwait(false);

            Posts = response.Deserialize<Response<List<Post>>>()?.Result ?? new List<Post>();
        }

        protected void Publish()
        {
        }

        protected void Unpublish()
        {
        }

        private async Task RequestApiAsync(string href, string method)
        {
            var request = RequestHelper.CreateRequest(href, method);

            _ = await Client.SendAsync(request).ConfigureAwait(false);

            var response = await Client.GetStringAsync(new Uri("/api/blog", UriKind.Relative)).ConfigureAwait(false);
            Posts = response.Deserialize<Response<List<Post>>>()?.Result ?? new List<Post>();
        }
    }
}