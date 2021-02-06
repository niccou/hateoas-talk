using System.Collections.Generic;
using System.Net.Http;
using TechTalk.SpecFlow;
using WebApi.Core.Models;
using WebApi.Models;
using WebApi.Tests.Bindings.Shared;
using WebApi.Tests.Shared;
using Xunit;

namespace WebApi.Tests.Bindings.GestionDuBlog
{
    public class BlogContext : ContextBase, IClassFixture<ApiServer>
    {
        protected BlogContext(ScenarioContext context, ApiServer server) : base(context) => Server = server;

        protected HttpResponseMessage? Response
        {
            get => Get<HttpResponseMessage>();
            set => Set(value);
        }

        protected ICollection<PostDto>? Posts
        {
            get => Get<ICollection<PostDto>?>();
            set => Set(value);
        }

        protected ApiServer? Server
        {
            get => Get<ApiServer>();
            private set => Set(value);
        }

        protected Author? CurrentAuthor
        {
            get => Get<Author>();
            set => Set(value);
        }
    }
}
