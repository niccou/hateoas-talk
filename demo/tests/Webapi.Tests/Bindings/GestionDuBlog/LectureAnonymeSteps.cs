using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApi.Core.Models;
using WebApi.Models;
using WebApi.Tests.Shared;

namespace WebApi.Tests.Bindings.GestionDuBlog
{
    [Binding]
    public class LectureAnonymeSteps : BackgroundSteps
    {
        public LectureAnonymeSteps(ScenarioContext context, ApiServer server) : base(context, server) { }

        [Given("Je suis anonyme")]
        public void GivenJeSuisAnonyme()
        {
            CurrentAuthor = null;
        }

        [When("Je veux voir le blog")]
        public async Task WhenJeVeuxVoirLeBlog()
        {
            Response = await Server!.Client.GetAsync(new Uri("/blog", UriKind.Relative)).ConfigureAwait(false);
        }

        [Then("Je recois une liste de posts")]
        public async Task ThenJeRecoisUneListeDePosts()
        {

            Response!.EnsureSuccessStatusCode();

            Posts = await Response.Content
                .ReadAsStringAsync()
                .ContinueWith(read => read.Result.Deserialize<ICollection<PostDto>>())
                .ConfigureAwait(false);

            Posts.Should().NotBeNull();
        }

        [Then("Je vois uniquement les posts")]
        public void ThenJeVoisUniquementLesPosts(Table table)
        {
            Posts.Should().BeEquivalentTo(table.CreateSet(CreatePostDto));
        }

        private static PostDto CreatePostDto(TableRow row) => new PostDto
        {
            Author = row["Author"],
            Title = row["Title"],
            Description = row["Description"],
        };
    }
}
