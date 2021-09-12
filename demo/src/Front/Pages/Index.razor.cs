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
            var response = await Client.GetStringAsync(new Uri("/api/v1/blog", UriKind.Relative)).ConfigureAwait(false);

            Posts = response.Deserialize<Response<List<Post>>>()?.Result ?? new List<Post>();
        }
    }
}