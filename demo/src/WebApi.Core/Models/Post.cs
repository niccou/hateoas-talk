namespace WebApi.Core.Models
{
    public record Post
    {
        public enum PostState
        {
            Draft,
            Published
        }

        public string Title { get; init; } = "";
        public string Description { get; init; } = "";
        public Author Author { get; init; } = new Author();
        public PostState State { get; init; } = PostState.Draft;
    }
}
