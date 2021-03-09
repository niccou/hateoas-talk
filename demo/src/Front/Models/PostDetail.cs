namespace Front.Models
{
    public record PostDetail : Post
    {
        public string Content { get; init; } = "";
    }
}