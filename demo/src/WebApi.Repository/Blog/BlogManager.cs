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
        private static Faker Faker { get; } = new Faker("fr");

        private static Core.Models.Blog InternalBlog { get; set; } = new Core.Models.Blog
        {
            Posts = new List<Post>
            {
                new Post{ Id = "Published1", Title = "Analysis Patterns", Description = Faker.Lorem.Paragraphs(2, 5), Author = new Author{Name = "Martin Fowler"}, State = Post.PostState.Published },
                new Post{ Id = "Published2", Title = "Domain Driven Design", Description = Faker.Lorem.Paragraphs(2, 5), Author = new Author{Name = "Eric Evans"}, State = Post.PostState.Published },
                new Post{ Id = "Unpublished1", Title = Faker.Lorem.Sentence(), Description = Faker.Lorem.Paragraphs(2, 5), Author = new Author{Name = "Martin Fowler"}, State = Post.PostState.Draft },
                new Post{ Id = "Unpublished2", Title = Faker.Lorem.Sentence(), Description = Faker.Lorem.Paragraphs(2, 5), Author = new Author{Name = "Eric Evans"}, State = Post.PostState.Draft }
            }
        };

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