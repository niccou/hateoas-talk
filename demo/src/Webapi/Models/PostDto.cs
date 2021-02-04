namespace WebApi.Models
{
    public record PostDto
    {
        public string Author { get; init; } = "";
        public string Title { get; init; } = "";
        public string Description { get; init; } = "";
    }
}
