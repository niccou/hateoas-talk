using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApi.Core.Blog;
using WebApi.Core.Models;
using WebApi.Models;
using WebApi.Tests.Shared;

namespace WebApi.Tests.Bindings.GestionDuBlog
{
    public class BlogBackgroundSteps : BlogContext
    {
        protected BlogBackgroundSteps(ScenarioContext context, ApiServer server) : base(context, server) { }

        private Mock<IGetBlog> BlogMock { get; } = new Mock<IGetBlog>();

        [Given("Je démarre le blog")]
        public void GivenJeDemarreLeBlog(Table table)
        {
            var posts = CreatePostsCollection(table);

            BlogMock.Setup(_ => _.Get()).Returns(new Blog
            {
                Posts = posts
            });

            Server!.ConfigureWebHost = builder =>
                builder.ConfigureTestServices(services =>
                    services.AddTransient(_ => BlogMock.Object));
        }

        [When("Je veux voir le blog")]
        public async Task WhenJeVeuxVoirLeBlog()
        {
            var route = "/blog";

            if (CurrentAuthor != new Author())
            {
                route += $"?Name={ CurrentAuthor!.Name}";
            }
            Response = await Server!.Client.GetAsync(new Uri(route, UriKind.Relative)).ConfigureAwait(false);
        }

        [When("Je veux voir le post (.*)")]
        public async Task WhenJeVeuxVoirLePost(string title)
        {
            var route = $"/blog/post?title{title}";

            Response = await Server!.Client.GetAsync(new Uri(route, UriKind.Relative)).ConfigureAwait(false);
        }

        [Then("Je recois un détail de post")]
        public async Task ThenJeRecoisUnDetailDePost()
        {
            Response!.EnsureSuccessStatusCode();

            PostDetail = await Response.Content
                .ReadAsStringAsync()
                .ContinueWith(read => read.Result.Deserialize<PostDetailDto>())
                .ConfigureAwait(false);

            PostDetail.Should().NotBeNull();
        }

        [Then("Je recois une liste de posts")]
        public async Task ThenJeRecoisUneListeDePosts()
        {
            Response!.EnsureSuccessStatusCode();

            PostSummaries = await Response.Content
                .ReadAsStringAsync()
                .ContinueWith(read => read.Result.Deserialize<ICollection<PostSummaryDto>>())
                .ConfigureAwait(false);

            PostSummaries.Should().NotBeNull();
        }

        [Then("Je vois uniquement les posts")]
        public void ThenJeVoisUniquementLesPosts(Table table)
        {
            PostSummaries.Should().BeEquivalentTo(table.CreateSet(CreatePostDto));
        }

        private static PostSummaryDto CreatePostDto(TableRow row) => new PostSummaryDto
        {
            Author = row["Author"],
            Title = row["Title"]
        };

        private static IReadOnlyCollection<Post> CreatePostsCollection(Table table)
            => table.CreateSet(r => new Post
            {
                Title = r["Title"],
                Description = r["Description"],
                State = Enum.Parse<Post.PostState>(r["State"], true),
                Author = new Author { Name = r["Author"] }
            })
            .ToList();
    }
}
