using Bogus;
using System.Collections.Generic;
using WebApi.Core.Blog;
using WebApi.Core.Models;

namespace WebApi.Repository.Blog
{
    internal class GetBlog : IGetBlog
    {
        private static Faker Faker { get; } = new Faker("fr");

        private Core.Models.Blog InternalBlog { get; } = new Core.Models.Blog
        {
            Posts = new List<Post>
            {
                new Post{ Title = "Analysis Patterns", Description = Faker.Lorem.Paragraphs(2, 5), Author = new Author{Name = "Martin Fowler"}, State = Post.PostState.Published },
                new Post{ Title = "Domain Driven Design", Description = Faker.Lorem.Paragraphs(2, 5), Author = new Author{Name = "Eric Evans"}, State = Post.PostState.Published },
                new Post{ Title = Faker.Lorem.Sentence(), Description = Faker.Lorem.Paragraphs(2, 5), Author = new Author{Name = "Martin Fowler"}, State = Post.PostState.Draft },
                new Post{ Title = Faker.Lorem.Sentence(), Description = Faker.Lorem.Paragraphs(2, 5), Author = new Author{Name = "Eric Evans"}, State = Post.PostState.Draft }
            }
        };

        public Core.Models.Blog Get() => InternalBlog;
    }
}