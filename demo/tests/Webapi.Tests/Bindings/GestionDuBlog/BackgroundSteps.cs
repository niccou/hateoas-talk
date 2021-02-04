using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApi.Core.Blog;
using WebApi.Core.Models;
using WebApi.Tests.Shared;

namespace WebApi.Tests.Bindings.GestionDuBlog
{
    public class BackgroundSteps : Context
    {
        protected BackgroundSteps(ScenarioContext context, ApiServer server) : base(context, server) { }

        private Mock<IGetBlog> BlogMock { get; } = new Mock<IGetBlog>();

        [Given("Je démarre l'api avec les posts suivant")]
        public void GivenJeDemarreLApiAvecLesPostsSuivant(Table table)
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
