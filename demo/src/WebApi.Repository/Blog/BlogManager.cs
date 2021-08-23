using Bogus;
using System.Collections.Generic;
using System.Linq;
using WebApi.Core.Models;
using WebApi.Core.Services;
using WebApi.Core.Shared;

namespace WebApi.Repository.Blog
{
    internal class BlogManager : IGetBlog, IPublishPost
    {
        private const string IdFormat = "N";
        private static Faker Faker => new Faker("fr");

        private static Core.Models.Blog InternalBlog { get; set; } = new Core.Models.Blog
        {
            Posts = new List<Post>
            {
                new Post{ Id = GenerateId(), Title = Faker.Lorem.Sentence(), Description = Faker.Lorem.Paragraphs(2, 5), Author = new Author{Name = Faker.Person.FullName}, State = Post.PostState.Published },
                new Post{ Id = GenerateId(), Title = Faker.Lorem.Sentence(), Description = Faker.Lorem.Paragraphs(2, 5), Author = new Author{Name = Faker.Person.FullName}, State = Post.PostState.Published },
                new Post{ Id = GenerateId(), Title = Faker.Lorem.Sentence(), Description = Faker.Lorem.Paragraphs(2, 5), Author = new Author{Name = Faker.Person.FullName}, State = Post.PostState.Draft },
                new Post{ Id = GenerateId(), Title = Faker.Lorem.Sentence(), Description = Faker.Lorem.Paragraphs(2, 5), Author = new Author{Name = Faker.Person.FullName}, State = Post.PostState.Draft }
            }
        };

        private static string GenerateId() => System.Guid.NewGuid().ToString(IdFormat);

        public OperationResult<Core.Models.Blog> Get() => OperationResult<Core.Models.Blog>.Succeed(InternalBlog);

        public OperationResult Publish(string id) => PublishUnpublish(id, Post.PostState.Draft, Post.PostState.Published);

        public OperationResult Unpublish(string id) => PublishUnpublish(id, Post.PostState.Published, Post.PostState.Draft);

        private static OperationResult PublishUnpublish(string id, Post.PostState initialState, Post.PostState newState)
        {
            var posts = InternalBlog.Posts.ToList();
            var post = posts.SingleOrDefault(_ => _.Id == id && _.State == initialState);

            if (post is null)
            {
                return OperationResult.Failed();
            }

            posts.Remove(post);

            posts.Add(post with { State = newState });

            InternalBlog = InternalBlog with { Posts = posts };

            return OperationResult.Succeed();
        }
    }
}